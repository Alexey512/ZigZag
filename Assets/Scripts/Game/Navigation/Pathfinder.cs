using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Game.Navigation
{
	public class Pathfinder: IPathfinder
	{
		private readonly float _maxHitDistance = 1f;

		public bool CalculatePath(Vector3 start, Vector3 end, out Vector3[] path)
		{
			NavMeshHit hitTarget;
			NavMeshHit hitSource;
			var meshPath = new NavMeshPath();
			if (NavMesh.SamplePosition(start, out hitSource, _maxHitDistance, NavMesh.AllAreas) &&
			    NavMesh.SamplePosition(end, out hitTarget, _maxHitDistance, NavMesh.AllAreas) &&
			    NavMesh.CalculatePath(hitSource.position, hitTarget.position, NavMesh.AllAreas, meshPath))
			{
				path = meshPath.corners;
				return true;
			}
			path = new Vector3[0];
			return false;
		}
	}
}
