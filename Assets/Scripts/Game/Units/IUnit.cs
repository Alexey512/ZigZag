using UnityEngine;

namespace Assets.Scripts.Game.Units
{
	public interface IUnit: IMovable
	{
		GameObject Owner { get; }

		float Attack { get; set; }

		float HP { get; set; }
	}
}
