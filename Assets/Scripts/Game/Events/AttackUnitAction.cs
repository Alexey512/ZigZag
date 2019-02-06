using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class AttackUnitAction: AttackUnitEvent.ISubscribed
	{
		private readonly IUnitsFactory _unitsFactory;

		private readonly ICommandsManager _commandsManager;

		private readonly IGameScene _gameScene;

		public AttackUnitAction(IGameScene gameScene, IUnitsFactory unitsFactory, ICommandsManager commandsManager)
		{
			_unitsFactory = unitsFactory;
			_commandsManager = commandsManager;
			_gameScene = gameScene;
		}

		public void OnEvent(IUnit source, IUnit target)
		{
			if (target.HP <= 0)
				return;

			IUnit rocket = _unitsFactory.CreateUnit<IUnit>("rocket_0");
			rocket.Position = new Vector3(source.Position.x, 1.0f, source.Position.z);
			Vector3 targetPosition = new Vector3(target.Position.x, 1.0f, target.Position.z);

			target.HP -= source.Attack;

			var moveRocketCmd = new SequenceCommand(
				new MoveByPath(rocket, new Vector3[] { rocket.Position, targetPosition }, 3f ),
				new PunchUnit(rocket, Vector3.one, 1f),
				new UpdateUnitHP(target),
				new ActionCommand(() =>
				{
					GameObject.Destroy(rocket.Owner);
				})
			);

			if (target.HP <= 0)
			{
				moveRocketCmd.Commands.Add(new PunchUnit(target, Vector3.one, 1f));
				moveRocketCmd.Commands.Add(new ActionCommand(() =>
				{
					_gameScene.Units.Remove(target);
					GameObject.Destroy(target.Owner);
				}));
			}

			_commandsManager.ExecuteCommand(moveRocketCmd);
		}
	}
}
