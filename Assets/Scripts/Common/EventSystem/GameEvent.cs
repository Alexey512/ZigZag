using System;

namespace Assets.Scripts.Game.EventSystem
{
	public class GameEvent<TEvent> where TEvent : GameEvent<TEvent>
	{
		public interface IEventHandler
		{
			void OnEvent(TEvent args);
		}
	}

	/*public interface IEventHandler<TEvent> where TEvent: EventArgs;
	{
		void OnEvent(TEvent hit);
	}*/
}
