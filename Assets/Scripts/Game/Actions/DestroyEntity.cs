using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;

namespace Assets.Scripts.Game.Actions
{
    public class DestroyEntity: GameTask
    {
        protected override void OnStart()
        {
            var entity = Context.GetValue<IGameEntity>(ActionConsts.Unit);
            entity.Destroy();
            End(ActionStatus.Success);
        }
    }
}
