using System;

namespace Assets.Scripts.Common.EventAggregator
{
    public interface IPublished<TEvent> : IPublished
        where TEvent : IAggrEvent
    {
        Func<TEvent> Event1 { get; set; }
    }

    public interface IPublished<TEvent1, TEvent2> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
    }

    public interface IPublished<TEvent1, TEvent2, TEvent3> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
    }

    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
    }
    
    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
    }
    
    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5, TEvent6> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
        where TEvent6 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
        Func<TEvent6> Event6 { get; set; }
    }
    
    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5, TEvent6, TEvent7> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
        where TEvent6 : IAggrEvent
        where TEvent7 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
        Func<TEvent6> Event6 { get; set; }
        Func<TEvent7> Event7 { get; set; }
    }
    
        
    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5, TEvent6, TEvent7, TEvent8> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
        where TEvent6 : IAggrEvent
        where TEvent7 : IAggrEvent
        where TEvent8 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
        Func<TEvent6> Event6 { get; set; }
        Func<TEvent7> Event7 { get; set; }
        Func<TEvent8> Event8 { get; set; }
    }
    
    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5, TEvent6, TEvent7, TEvent8, TEvent9> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
        where TEvent6 : IAggrEvent
        where TEvent7 : IAggrEvent
        where TEvent8 : IAggrEvent
        where TEvent9 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
        Func<TEvent6> Event6 { get; set; }
        Func<TEvent7> Event7 { get; set; }
        Func<TEvent8> Event8 { get; set; }
        Func<TEvent9> Event9 { get; set; }
    }

    public interface IPublished<TEvent1, TEvent2, TEvent3, TEvent4, TEvent5, TEvent6, TEvent7, TEvent8, TEvent9, TEvent10> : IPublished
        where TEvent1 : IAggrEvent
        where TEvent2 : IAggrEvent
        where TEvent3 : IAggrEvent
        where TEvent4 : IAggrEvent
        where TEvent5 : IAggrEvent
        where TEvent6 : IAggrEvent
        where TEvent7 : IAggrEvent
        where TEvent8 : IAggrEvent
        where TEvent9 : IAggrEvent
        where TEvent10 : IAggrEvent
    {
        Func<TEvent1> Event1 { get; set; }
        Func<TEvent2> Event2 { get; set; }
        Func<TEvent3> Event3 { get; set; }
        Func<TEvent4> Event4 { get; set; }
        Func<TEvent5> Event5 { get; set; }
        Func<TEvent6> Event6 { get; set; }
        Func<TEvent7> Event7 { get; set; }
        Func<TEvent8> Event8 { get; set; }
        Func<TEvent9> Event9 { get; set; }
        Func<TEvent10> Event10 { get; set; }
    }
    
    public interface IPublished
    {
    }
}