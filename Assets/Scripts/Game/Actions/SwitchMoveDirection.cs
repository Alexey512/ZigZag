using Assets.Scripts.Common.Actions;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class SwitchMoveDirection: GameTask
    {
        private IInputManager _input;

        private SharedValue<FieldCoords> _direction;

        public SwitchMoveDirection(IInputManager input)
        {
            _input = input;
        }

        protected override void OnStart()
        {
            _direction = Context.GetValue<SharedValue<FieldCoords>>(ActionConsts.UnitDirection);

            _input.OnMouseDown += InputOnOnClick;
        }

        private void InputOnOnClick(Vector3 obj)
        {
            _direction.Value = _direction.Value == FieldCoords.Top ? FieldCoords.Right : FieldCoords.Top;
        }

        protected override void OnEnd()
        {
            _input.OnMouseDown -= InputOnOnClick;
            _direction = null;
        }
    }
}
