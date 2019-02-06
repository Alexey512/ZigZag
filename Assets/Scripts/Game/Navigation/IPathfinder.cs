using UnityEngine;

namespace Assets.Scripts.Game.Navigation
{
	public interface IPathfinder
	{
		bool CalculatePath(Vector3 start, Vector3 end, out Vector3[] path);
	}
}
