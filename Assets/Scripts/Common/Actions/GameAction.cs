using System;
using Game.Actions;
using UnityEngine;

namespace Assets.Scripts.Common.Actions
{
    public class GameAction : IGameAction
    {
        public event Action<IGameAction> Started;

        public event Action<IGameAction> Ended;

        private ActionStatus _status = ActionStatus.Inactive;

        public ActionStatus Status => _status;

        public void Start()
        {
            if (_status == ActionStatus.Running)
                return;
            _status = ActionStatus.Running;
            OnReset();
            OnStart();
            Started?.Invoke(this);
        }

        public void End(ActionStatus status)
        {
            if (_status != ActionStatus.Running)
                return;
            _status = status;
            OnEnd();
            Ended?.Invoke(this);
        }

        public void Update()
        {
            OnUpdate();
        }

        protected virtual void OnReset()
        {

        }

        protected virtual void OnStart()
        {

        }

        protected virtual void OnEnd()
        {

        }

        protected virtual void OnUpdate()
        {

        }
    }
}
