using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Common.EventAggregator
{
    /// <summary>
    /// Collecting knowledge from clever people ...
    /// </summary>
    public sealed partial class EventAggregator : ISubscriber
    {
        private readonly IDictionary<Type, List<WeakReference>> _eventSubscriberLists =
            new Dictionary<Type, List<WeakReference>>(TypeComparer);

        public void Subscribe(object subscriber)
        {
            var subscriberTypes = GetAllSubscriberTypes(subscriber);
            var weakReference = new WeakReference(subscriber);

            foreach (var subscriberType in subscriberTypes)
            {
                var subscribers = GetSubscribers(subscriberType);
                subscribers.Add(weakReference);
            }
        }

        public void UnSubscribe(object subscriber)
        {
            var subscriberTypes = GetAllSubscriberTypes(subscriber);

            foreach (var subscriberType in subscriberTypes)
            {
                var subscribers = GetSubscribers(subscriberType);
                subscribers.RemoveAll(obj => obj.Target.Equals(subscriber));
            }
        }

        private static IEnumerable<Type> GetAllSubscriberTypes(object subscriber)
        {
            return subscriber.GetType().GetInterfaces().Where(i =>
            {
                var typeDefinition = i.GetGenericTypeDefinition();
                return i.IsGenericType && (
                           typeDefinition == typeof(EventHub<>.ISubscribed) ||
                           typeDefinition == typeof(EventHub<,>.ISubscribed) ||
                           typeDefinition == typeof(EventHub<,,>.ISubscribed) ||
                           typeDefinition == typeof(EventHub<,,,>.ISubscribed));
            });
        }

        public void Publish<TEvent>() where TEvent : EventHub<TEvent>
        {
            var subscriberType = typeof(EventHub<TEvent>.ISubscribed);
            var subscribers = GetCleanSubscribers(subscriberType).ToList();
            foreach (var subWeak in subscribers.ToList())
            {
                var subscriber = (EventHub<TEvent>.ISubscribed) subWeak.Target;
                subscriber.OnEvent();
            }
        }

        private IEnumerable<WeakReference> GetCleanSubscribers(Type subscriberType)
        {
            var subscribers = GetSubscribers(subscriberType);
            subscribers.RemoveAll(sub => !sub.IsAlive);
            return subscribers;
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            var isExists = _eventSubscriberLists.TryGetValue(subscriberType, out subscribers);
            if (isExists) 
                return subscribers;
            
            subscribers = new List<WeakReference>();
            _eventSubscriberLists.Add(subscriberType, subscribers);

            return subscribers;
        }
    }

    public sealed partial class EventAggregator
    {
        #region Publish

        public void Publish<TEvent, TValue>(TValue value)
            where TEvent : EventHub<TEvent, TValue>
        {
            var subscriberType = typeof(EventHub<TEvent, TValue>.ISubscribed);
            var subscribers = GetCleanSubscribers(subscriberType);
            foreach (var subWeak in subscribers.ToList())
            {
                var subscriber = (EventHub<TEvent, TValue>.ISubscribed) subWeak.Target;
                subscriber.OnEvent(value);
            }
        }

        public void Publish<TEvent, TValue1, TValue2>(TValue1 value1, TValue2 value2)
            where TEvent : EventHub<TEvent, TValue1, TValue2>
        {
            var subscriberType = typeof(EventHub<TEvent, TValue1, TValue2>.ISubscribed);
            var subscribers = GetCleanSubscribers(subscriberType);

            foreach (var subWeak in subscribers.ToList())
            {
                var subscriber = (EventHub<TEvent, TValue1, TValue2>.ISubscribed) subWeak.Target;
                subscriber.OnEvent(value1, value2);
            }
        }

        public void Publish<TEvent, TValue1, TValue2, TValue3>(TValue1 value1, TValue2 value2, TValue3 value3)
            where TEvent : EventHub<TEvent, TValue1, TValue2, TValue3>
        {
            var subscriberType = typeof(EventHub<TEvent, TValue1, TValue2, TValue3>.ISubscribed);
            var subscribers = GetCleanSubscribers(subscriberType);

            foreach (var subWeak in subscribers.ToList())
            {
                var subscriber = (EventHub<TEvent, TValue1, TValue2, TValue3>.ISubscribed) subWeak.Target;
                subscriber.OnEvent(value1, value2, value3);
            }
        }

        #endregion Publish

        #region Subscribe

        public void Subscribe<TEvent>(EventHub<TEvent>.ISubscribed subscribed) where TEvent : EventHub<TEvent>
        {
            AddWeakReference(subscribed);
        }

        public void Subscribe<TEvent, TValue>(EventHub<TEvent, TValue>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue>
        {
            AddWeakReference(subscribed);
        }

        public void Subscribe<TEvent, TValue1, TValue2>(EventHub<TEvent,TValue1, TValue2>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue1, TValue2>
        {
            AddWeakReference(subscribed);
        }

        public void Subscribe<TEvent, TValue1, TValue2, TValue3>(
            EventHub<TEvent,TValue1, TValue2, TValue3>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue1, TValue2, TValue3>
        {
            AddWeakReference(subscribed);
        }

        private void AddWeakReference<TType>(TType subscriber)
        {
            var weakReference = new WeakReference(subscriber);
            var subscribers = GetSubscribers(typeof(TType));
            subscribers.Add(weakReference);
        }

        #endregion Subscribe

        #region UnSubscribe

        public void UnSubscribe<TEvent>(EventHub<TEvent>.ISubscribed subscribed) where TEvent : EventHub<TEvent>
        {
            RemoveWeakReference(subscribed);
        }

        public void UnSubscribe<TEvent, TValue>(EventHub<TEvent,TValue>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue>
        {
            RemoveWeakReference(subscribed);
        }

        public void UnSubscribe<TEvent, TValue1, TValue2>(EventHub<TEvent,TValue1, TValue2>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue1, TValue2>
        {
            RemoveWeakReference(subscribed);
        }

        public void UnSubscribe<TEvent, TValue1, TValue2, TValue3>(
            EventHub<TEvent,TValue1, TValue2, TValue3>.ISubscribed subscribed)
            where TEvent : EventHub<TEvent, TValue1, TValue2, TValue3>
        {
            RemoveWeakReference(subscribed);
        }

        private void RemoveWeakReference<TType>(TType subscriber)
        {
            var subscribers = GetSubscribers(typeof(TType));
            subscribers.RemoveAll(obj => obj.Target.Equals(subscriber));
        }

        #endregion UnSubscribe

        private sealed class TypeEqualityComparer : EqualityComparer<Type>
        {
            public override bool Equals(Type x, Type y)
            {
                if (x == null && y == null) return true;
                if (x == null || y == null) return false;
                return y == x;
            }

            public override int GetHashCode(Type type)
            {
                return type != null ? type.GetHashCode() : 0;
            }
        }

        public static EqualityComparer<Type> TypeComparer { get; } = new TypeEqualityComparer();
    }
}