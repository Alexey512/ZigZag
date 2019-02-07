using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.UI.Controller;

namespace Assets.Scripts.Game.Events
{
    public sealed class EndGameEvent : GameEvent<EndGameEvent>
    {
    }


    public sealed class EndGameHandler : EndGameEvent.IEventHandler
    {
        private StartWindow.Factory _startWindowFactory;

        public EndGameHandler(StartWindow.Factory startWindowFactory)
        {
            _startWindowFactory = startWindowFactory;
        }

        public void OnEvent(EndGameEvent args)
        {
            _startWindowFactory.Create();
        }
    }
}
