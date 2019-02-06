using System.Linq;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Model;

namespace Assets.Scripts.Game.Actions
{
    public class DestroyTile: GameTask
    {
        private GameField _field;

        public DestroyTile(GameField field)
        {
            _field = field;
        }

        protected override void OnStart()
        {
            var entity = Context.GetValue<IGameEntity>(ActionConsts.Unit);

            var element = _field.Elements.FirstOrDefault(e => e.Entity == entity);
            if (element != null)
            {
                element.Destroy();
            }
            else
            {
                entity.Destroy();
            }

            End(ActionStatus.Success);
        }
    }
}
