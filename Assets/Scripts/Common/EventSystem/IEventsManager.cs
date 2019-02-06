namespace Assets.Scripts.Game.EventSystem
{
	public interface IEventsManager
	{
		void PublishEvent<TEvent>(TEvent gameEvent) where TEvent : GameEvent<TEvent>;

		//void RegisterEvent<TEvent>(GameEvent<TEvent>.IEventHandler handler) where TEvent : GameEvent<TEvent>;

		//void UnregisterEvent<TEvent>();
	}
}
