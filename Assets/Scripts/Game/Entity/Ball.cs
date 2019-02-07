using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Score;
using Assets.Scripts.Game.UI.Controller;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Ball : GameEntity
    {
        [Inject]
        public void Construct(IInputManager input, StartWindow.Factory startWindow, IScoreManager scoreManager)
        {
            var createState = new Sequence(
                new ParallelSelector(
                    new MoveUnit(),
                    new SwitchMoveDirection(input),
                    new CheckUnitInField()
                ),
                new DropBall(),
                new CustomAction(c =>
                {
                    scoreManager.Finish();
                    startWindow.Create();
                }),
                new DestroyEntity()
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
