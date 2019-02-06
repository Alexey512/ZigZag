using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Commands
{
	public class UpdateUnitHP: Command
	{
		private readonly IUnit _unit;

		public UpdateUnitHP(IUnit unit)
		{
			_unit = unit;
		}

		protected override void OnExecute()
		{
			var label = _unit.Owner.GetComponentInChildren<TextMesh>();
			if (label != null)
			{
				label.text = _unit.HP.ToString();
			}
			Finish();
		}

		protected override void OnTerminate()
		{
			throw new System.NotImplementedException();
		}
	}
}
