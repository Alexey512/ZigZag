using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.Factory;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CheckUnitLeave: GameTask
    {
        private IGameEntity _entity;

        private TriggerListener _listener;

        protected override void OnStart()
        {
            _entity = Context.GetValue<IGameEntity>(ActionConsts.Unit);
            _listener = _entity.Owner.GetComponentInChildren<TriggerListener>();
            _listener.TriggerExit += OnTriggerExit;
        }
        private void OnTriggerExit(IGameEntity obj)
        {
            //if (obj.ObjectType == EntityType.Ball)
            if (obj is Ball)
            {
                End(ActionStatus.Success);
            }
        }

        protected override void OnEnd()
        {
            _listener.TriggerExit -= OnTriggerExit;
            _entity = null;
        }
    }
}
