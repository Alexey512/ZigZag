using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Zenject;

namespace Assets.Scripts.Common.EventAggregator
{
    public class Publisher : IPublisher
    {
        private readonly DiContainer _container;

        private readonly Dictionary<Type, IAggrEvent> _eventPool =
            new Dictionary<Type, IAggrEvent>(EventAggregator.TypeComparer);

        private static readonly Type PublisherType = typeof(Publisher);
        private static readonly Type PublishedType = typeof(IPublished);

        public Publisher(DiContainer container, List<IPublished> publisheds)
        {
            _container = container;
            foreach (var published in publisheds)
            {
                Bind(published);
            }
        }

        #region Bind

        public void Bind(object published)
        {
            var asPablished = published as IPublished;
            if (asPablished != null)
                Bind(asPablished);
        }

        public void Bind<TPublished>(TPublished published) where TPublished : IPublished
        {
            var type = published.GetType();
            var properties = EventProperties(type);
            foreach (var propertyInfo in properties)
            {
                var propertyType = propertyInfo.PropertyType;
                var returnType = propertyType.GetGenericArguments()[0];
                var eventResolve = PublisherType
                    .GetMethod("EventResolve", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(returnType);
                var del = Delegate.CreateDelegate(propertyType, this, eventResolve);
                propertyInfo.SetValue(published, del);
            }
        }

        private static IEnumerable<PropertyInfo> EventProperties(Type type)
        {
            var types = type.GetInterfaces().Where(i => i.IsGenericType).Where(i => PublishedType.IsAssignableFrom(i));
            var list = new List<PropertyInfo>();
            foreach (var @interface in types)
            {
                var count = @interface.GenericTypeArguments.Length;
                for (var i = 1; i <= count; i++)
                    list.Add(@interface.GetProperty($"Event{i}"));
            }

            return list;
        }

        private TEvent EventResolve<TEvent>() where TEvent : IAggrEvent
        {
            IAggrEvent eventAggr;
            var type = typeof(TEvent);
            var isExist = _eventPool.TryGetValue(type, out eventAggr);
            if (isExist)
                return (TEvent) eventAggr;

            var eventAggrFull = _container.Resolve<TEvent>();
            _eventPool.Add(type, eventAggrFull);
            return eventAggrFull;
        }

        #endregion

        public void Publish<TEvent>() where TEvent : EventHub<TEvent>
        {
            IAggrEvent eventAggr;
            var type = typeof(TEvent);
            var isExist = _eventPool.TryGetValue(type, out eventAggr);
            if (isExist)
                ((TEvent) eventAggr).Publish();
            else
            {
                var eventAggrFull = _container.Resolve<TEvent>();
                _eventPool.Add(type, eventAggrFull);
                eventAggrFull.Publish();
            }
        }

        public void Publish<TEvent, TValue>(TValue value) where TEvent : EventHub<TEvent, TValue>
        {
            IAggrEvent eventAggr;
            var type = typeof(TEvent);
            var isExist = _eventPool.TryGetValue(type, out eventAggr);
            if (isExist)
                ((TEvent) eventAggr).Publish(value);
            else
            {
                var eventAggrFull = _container.Resolve<TEvent>();
                _eventPool.Add(type, eventAggrFull);
                eventAggrFull.Publish(value);
            }
        }

        public void Publish<TEvent, TValue1, TValue2>(TValue1 value1, TValue2 value2)
            where TEvent : EventHub<TEvent, TValue1, TValue2>
        {
            IAggrEvent eventAggr;
            var type = typeof(TEvent);
            var isExist = _eventPool.TryGetValue(type, out eventAggr);
            if (isExist)
                ((TEvent) eventAggr).Publish(value1, value2);
            else
            {
                var eventAggrFull = _container.Resolve<TEvent>();
                _eventPool.Add(type, eventAggrFull);
                eventAggrFull.Publish(value1, value2);
            }
        }

        public void Publish<TEvent, TValue1, TValue2, TValue3>(TValue1 value1, TValue2 value2, TValue3 value3)
            where TEvent : EventHub<TEvent, TValue1, TValue2, TValue3>
        {
            IAggrEvent eventAggr;
            var type = typeof(TEvent);
            var isExist = _eventPool.TryGetValue(type, out eventAggr);
            if (isExist)
                ((TEvent) eventAggr).Publish(value1, value2, value3);
            else
            {
                var eventAggrFull = _container.Resolve<TEvent>();
                _eventPool.Add(type, eventAggrFull);
                eventAggrFull.Publish(value1, value2, value3);
            }
        }
    }
}