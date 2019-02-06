using System.Collections.Generic;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CreateStartField: GameTask
    {
        private GameField _field;

        public CreateStartField(GameField field)
        {
            _field = field;
        }

        protected override void OnStart()
        {
            _field.CreateStart();

            End(ActionStatus.Success);
        }
    }
}
