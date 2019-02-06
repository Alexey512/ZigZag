using System.Linq;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Factory;
using Assets.Scripts.Game.Model;
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

        private readonly Tile.Factory _tileFactory;

        private readonly Ball.Factory _ballFactory;

        private readonly Crystal.Factory _crystalFactory;

        private const int _startSize = 3;

        private float _tileSize = 1f;

        private IGameAction _createAction;

        public CreateGameHandler(GameField field, FieldElement.Factory elementsFactory, Ball.Factory ballFactory, Crystal.Factory crystalFactory)
        {
            _ballFactory = ballFactory;
            _crystalFactory = crystalFactory;

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

            var ball = _ballFactory.Create();
            var c = _startSize * _tileSize / 2;
            ball.Position = new Vector3(c, 0.14f, c);
        }
    }
}
