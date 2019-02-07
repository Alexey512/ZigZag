using System.Linq;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Factory;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.UI.Controller;
using Game.Objects.Logic;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
    public sealed class CreateGameEvent: GameEvent<CreateGameEvent>
    {
    }


    public sealed class CreateGameHandler: CreateGameEvent.IEventHandler
    {
        private readonly IGameScene _scene;

        private IGameAction _createAction;

        private ScoreWindow.Factory _scoreWindow;

        public CreateGameHandler(GameField field)
        {
            _createAction = new Sequence(
                new CreateStartField(field),
                new LoopAction(
                    new CreateNewTile(field), 30
               )
             );
        }

        public void OnEvent(CreateGameEvent args)
        {
            _createAction.Start();
        }
    }
}
