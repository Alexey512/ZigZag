using System;
using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Navigation;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class MoveUnitByLoopAction: MoveUnitByPathEvent.ISubscribed
	{
		private readonly IUnitCommandsStorage _commandsStorage;

		private readonly IPathfinder _pathfinder;

		public MoveUnitByLoopAction(IPathfinder pathfinder, IUnitCommandsStorage commandsStorage)
		{
			_pathfinder = pathfinder;
			_commandsStorage = commandsStorage;
		}

		public void OnEvent(IUnit unit, Vector3 position)
		{
			_commandsStorage.TerminateCommand(unit);

			Vector3[] path;
			if (!_pathfinder.CalculatePath(unit.Position, position, out path))
				return;

			Vector3[] reversePath = new Vector3[path.Length];
			Array.Copy(path, reversePath, path.Length);
			Array.Reverse(reversePath);

			var unitCmd = new SequenceCommand(
				new MoveByPath(unit, path, 5),
				new PunchUnit(unit, Vector3.one, 1.5f),
				new MoveByPath(unit, reversePath, 5)
			);

			_commandsStorage.ExecuteCommand(unit, unitCmd);
			
		}
	}
}
