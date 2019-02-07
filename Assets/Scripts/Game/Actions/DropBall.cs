using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class DropBall : GameTask
    {
        private FieldCoords _direction;

        private float _speed;

        private GameEntity _unit;

        private float _time = 2f;

        private float _leftTime;

        protected override void OnStart()
        {
            _direction = Context.GetValue<SharedValue<FieldCoords>>(ActionConsts.UnitDirection).Value;
            _speed = Context.GetValue<SharedValue<float>>(ActionConsts.UnitSpeed).Value * 1.5f;
            _unit = Context.GetValue<GameEntity>(ActionConsts.Unit);
            _leftTime = _time;
        }

        protected override void OnUpdate()
        {
            if (_leftTime < 0)
            {
                End(ActionStatus.Success);
                return;
            }

            _leftTime -= Time.deltaTime;

            Vector3 direction = new Vector3(_direction.X, -(_time - _leftTime) / _time * _speed, _direction.Y);
            Vector3 newPosition = _unit.Position + direction * _speed * Time.deltaTime;
            _unit.Position = newPosition;
        }

        protected override void OnEnd()
        {
            _unit = null;
        }
    }
}
