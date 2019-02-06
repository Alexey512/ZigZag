using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Crystal : GameEntity
    {
        [Inject]
        public new void Construct()
        {
            var createState = new Sequence(
                new CheckCrystal(),
                new DestroyEntity()
            );

            Behaiour.Register(BehaiourState.Create, createState);
        }

        public override void Enable()
        {
            base.Enable();

            var context = Behaiour.Context;
            context.SetValue(ActionConsts.Unit, this);

            Behaiour.SelectState(BehaiourState.Create);
        }

        public class Factory : PlaceholderFactory<Crystal>
        {
        }
    }
}
