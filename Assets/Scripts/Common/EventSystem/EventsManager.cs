using System;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Game.EventSystem
{
	public class EventsManager: IEventsManager
	{
	    private readonly DiContainer _container;

        public EventsManager(DiContainer container)
        {
            _container = container;
        }

	    public void PublishEvent<TEvent>(TEvent gameEvent) where TEvent : GameEvent<TEvent>
	    {
            var handlers = _container.ResolveAll<GameEvent<TEvent>.IEventHandler>();
	        foreach (var handler in handlers)
	        {
	            handler.OnEvent(gameEvent);
	        }
	    }

        /*private readonly Dictionary<Type, List<object>> registeredEvents = new Dictionary<Type, List<object>>();

		public void PublishEvent<TEvent>(TEvent gameEvent) where TEvent : GameEvent<TEvent>
		{
			List<object> handlers;
			if (!registeredEvents.TryGetValue(typeof(TEvent), out handlers))
				return;
			foreach (var handler in handlers)
			{
				(handler as GameEvent<TEvent>.IEventHandler)?.OnEvent(gameEvent);
			}
		}

		public void RegisterEvent<TEvent>(GameEvent<TEvent>.IEventHandler handler) where TEvent : GameEvent<TEvent>
		{
			Type evenType = typeof(TEvent);
			List<object> handlers;
			if (!registeredEvents.TryGetValue(evenType, out handlers))
			{
				handlers = new List<object>();
				registeredEvents[evenType] = handlers;
			}
			handlers.Add(handler);
		}

		public void UnregisterEvent<TEvent>()
		{
			registeredEvents.Remove(typeof(TEvent));
		}*/
    }
}
