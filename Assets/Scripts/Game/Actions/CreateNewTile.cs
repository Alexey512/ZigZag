using System.Linq;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.Model;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class CreateNewTile: GameTask
    {
        private GameField _field;

        public CreateNewTile(GameField field)
        {
            _field = field;
        }

        protected override void OnStart()
        {
            _field.CreateNext();

            End(ActionStatus.Success);
        }
    }
}
