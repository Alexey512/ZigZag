using UnityEngine;

namespace Assets.Scripts.Game.Units
{
	public interface IMovable
	{
		Vector3 Position { get; set; }

		Quaternion Rotation { get; set; }
	}
}
