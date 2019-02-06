using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class CreateUnitsAction: CreateUnitsEvent.ISubscribed
	{
		private readonly IGameScene _gameScene;

		private readonly IUnitsFactory _unitsFactory;

		private readonly ICommandsManager _commandsManager;

		public CreateUnitsAction(IGameScene gameScene, IUnitsFactory unitsFactory, ICommandsManager commandsManager)
		{
			_gameScene = gameScene;
			_unitsFactory = unitsFactory;
			_commandsManager = commandsManager;
		}

		public void OnEvent(List<Tuple<string, Vector3>> hit)
		{
			var updateHPCommand = new ParallelCommand();

			foreach (var data in hit)
			{
				IUnit unit = _unitsFactory.CreateUnit<IUnit>(data.Item1);
				unit.HP = 100;
				unit.Attack = 23;
				unit.Position = data.Item2;
				_gameScene.Units.Add(unit);
				updateHPCommand.Commands.Add(new UpdateUnitHP(unit));
			}

			_commandsManager.ExecuteCommand(updateHPCommand);
		}
	}
}
