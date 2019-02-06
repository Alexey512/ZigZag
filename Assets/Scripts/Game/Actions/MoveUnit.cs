using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class MoveUnit: GameTask
    {
        private SharedValue<FieldCoords> _direction;

        private SharedValue<float> _speed;

        private GameEntity _unit;

        private Rigidbody _body;

        protected override void OnStart()
        {
            _direction = Context.GetValue<SharedValue<FieldCoords>>(ActionConsts.UnitDirection);
            _speed = Context.GetValue<SharedValue<float>>(ActionConsts.UnitSpeed);
            _unit = Context.GetValue<GameEntity>(ActionConsts.Unit);
            _body = _unit.GetComponentInChildren<Rigidbody>();
        }

        protected override void OnUpdate()
        {
            Vector3 direction = new Vector3(_direction.Value.X, 0, _direction.Value.Y);
            Vector3 newPosition = _unit.Position + direction * _speed.Value * Time.deltaTime;
            //if (_body != null)
            //    _body.MovePosition(newPosition);
            //else
            //{
                _unit.Position = newPosition;
            //}
        }

        protected override void OnEnd()
        {
            _direction = null;
            _speed = null;
            _unit = null;
            _body = null;
        }
    }
}
