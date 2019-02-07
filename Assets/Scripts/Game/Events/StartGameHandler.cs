using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Model;

namespace Assets.Scripts.Game.Events
{
    public sealed class StartGameEvent: GameEvent<StartGameEvent>
    {
    }

    public class StartGameHandler: StartGameEvent.IEventHandler
    {
        private GameField _field;

        public StartGameHandler(GameField field)
        {
            _field = field;
        }

        public void OnEvent(StartGameEvent args)
        {
            if (_field.Ball == null)
                return;

            _field.Ball.Behaiour.SelectState(BehaiourState.Create);
        }
    }
}
