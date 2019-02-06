using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Actions;
using Assets.Scripts.Game.Model;
using Zenject;

namespace Assets.Scripts.Game.Entity
{
    public class Tile: GameEntity
    {
        private GameField _field;

        [Inject]
        public new void Construct(GameField field, FieldElement.Factory elementFactory)
        {
            _field = field;

            var createState = new Sequence(
                new CheckUnitLeave(),
                new CreateNewTile(field),
                new DestroyTile(field)
            );

            Behaiour.Register(BehaiourState.Create, createState);
        }

        public override void Enable()
        {
            base.Enable();

            var context = Behaiour.Context;
            context.SetValue(ActionConsts.Unit, this);

            //_behaiour.SelectState(BehaiourState.Create);
        }

        public class Factory : PlaceholderFactory<Tile>
        {
        }
    }
}
