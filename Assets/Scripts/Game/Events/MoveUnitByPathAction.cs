using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Navigation;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class MoveUnitByPathAction: MoveUnitByPathEvent.ISubscribed
	{
		private readonly IUnitCommandsStorage _commandsStorage;

		private readonly IPathfinder _pathfinder;

		public MoveUnitByPathAction(IPathfinder pathfinder, IUnitCommandsStorage commandsStorage)
		{
			_pathfinder = pathfinder;
			_commandsStorage = commandsStorage;
		}

		public void OnEvent(IUnit unit, Vector3 position)
		{
			_commandsStorage.TerminateCommand(unit);

			Vector3[] path;
			if (_pathfinder.CalculatePath(unit.Position, position, out path))
			{
				_commandsStorage.ExecuteCommand(unit, new MoveByPath(unit, path, 5));
			}
		}
	}
}
