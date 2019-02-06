namespace Assets.Scripts.Common.EventAggregator
{
    public interface IPublisher
    {
        void Bind(object published);
        
        void Bind<TPublished>(TPublished published) where TPublished : IPublished;
        
        void Publish<TEvent>() where TEvent : EventHub<TEvent>;
        
        void Publish<TEvent, TValue>(TValue value) where TEvent : EventHub<TEvent, TValue>;

        void Publish<TEvent, TValue1, TValue2>(TValue1 value1, TValue2 value2)
            where TEvent : EventHub<TEvent, TValue1, TValue2>;

        void Publish<TEvent, TValue1, TValue2, TValue3>(TValue1 value1, TValue2 value2, TValue3 value3)
            where TEvent : EventHub<TEvent, TValue1, TValue2, TValue3>;
    }
}