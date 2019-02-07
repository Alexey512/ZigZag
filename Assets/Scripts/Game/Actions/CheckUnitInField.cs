using System.Collections.Generic;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CheckUnitInField : GameTask
    {
        private IGameEntity _entity;

        protected override void OnStart()
        {
            _entity = Context.GetValue<IGameEntity>(ActionConsts.Unit);
        }

        protected override void OnUpdate()
        {
            if (!Physics.Raycast(_entity.Position, Vector3.down))
            {
                End(ActionStatus.Success);
            }
        }

        protected override void OnEnd()
        {
            _entity = null;
        }
    }
}
