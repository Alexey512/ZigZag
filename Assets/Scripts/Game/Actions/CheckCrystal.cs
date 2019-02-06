using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CheckCrystal: GameTask
    {
        private TriggerListener _listener;

        protected override void OnStart()
        {
            var entity = Context.GetValue<IGameEntity>(ActionConsts.Unit);
            _listener = entity.Owner.GetComponentInChildren<TriggerListener>();
            _listener.TriggerEnter += OnTriggerEnter;
        }

        private void OnTriggerEnter(IGameEntity obj)
        {
            if (obj is Ball)
            {
                End(ActionStatus.Success);
            }
        }

        protected override void OnEnd()
        {
            _listener.TriggerEnter -= OnTriggerEnter;
            _listener = null;
        }
    }
}
