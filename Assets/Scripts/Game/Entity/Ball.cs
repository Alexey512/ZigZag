using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Model;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Ball : GameEntity
    {
        [Inject]
        public void Construct(IInputManager input)
        {
            var createState = new Parallel(
                new MoveUnit(),
                new SwitchMoveDirection(input),
                new CheckUnitInField()
            );

            Behaiour.Register(BehaiourState.Create, createState);
        }

        public override void Enable()
        {
            base.Enable();

            var context = Behaiour.Context;
            context.SetValue(ActionConsts.UnitDirection, new SharedValue<FieldCoords>(FieldCoords.Top));
            context.SetValue(ActionConsts.UnitSpeed, new SharedValue<float>(2));
            context.SetValue(ActionConsts.Unit, this);

            Behaiour.SelectState(BehaiourState.Create);
        }

        public override void Disable()
        {
            base.Disable();
        }

        public class Factory : PlaceholderFactory<Ball>
        {
        }
    }
}
