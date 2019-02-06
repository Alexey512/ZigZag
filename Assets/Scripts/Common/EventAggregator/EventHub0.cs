using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Common.EventAggregator
{
    public abstract class EventHub<TEvent> : IAggrEvent
        where TEvent : EventHub<TEvent>, IAggrEvent
    {
        private EventAggregator _eventAggregator;
        [Inject]
        private void Construct(ISubscriber subscriber, List<ISubscribed> subscribers)
        {
            _eventAggregator = (EventAggregator) subscriber;
            foreach (var autoSubscriber in subscribers)
                Listen(autoSubscriber);
        }

        public void Publish()
        {
            _eventAggregator.Publish<TEvent>();
        }

        public void Listen(ISubscribed subscribed)
        {
            _eventAggregator.Subscribe(subscribed);
        }

        public void UnListen(ISubscribed subscribed)
        {
            _eventAggregator.UnSubscribe(subscribed);
        }

        public static TEvent operator +(EventHub<TEvent> eventHub, ISubscribed subscribed)
        {
            eventHub.Listen(subscribed);
            return (TEvent) eventHub;
        }

        public static TEvent operator -(EventHub<TEvent> eventHub, ISubscribed subscribed)
        {
            eventHub.UnListen(subscribed);
            return (TEvent) eventHub;
        }

        public interface ISubscribed
        {
            void OnEvent();
        }
    }
}