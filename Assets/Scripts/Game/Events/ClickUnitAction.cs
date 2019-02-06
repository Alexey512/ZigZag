using Assets.Scripts.Common.Commands;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game.Commands;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
	public sealed class ClickUnitAction: ClickUnitEvent.ISubscribed
	{
		private readonly IGameScene _gameScene;

		private readonly ICommandsManager _commandsManager;

		public ClickUnitAction(IGameScene gameScene, ICommandsManager commandsManager)
		{
			_gameScene = gameScene;
			_commandsManager = commandsManager;
		}

		public void OnEvent(IUnit hit)
		{
			var rootCmd = new ParallelCommand();

			if (_gameScene.SelectedUnit != null)
			{
				rootCmd.Commands.Add(new SetUnitColor(_gameScene.SelectedUnit, Color.white));
			}

			_gameScene.SelectedUnit = hit;
			rootCmd.Commands.Add(new SetUnitColor(_gameScene.SelectedUnit, Color.yellow));

			_commandsManager.ExecuteCommand(rootCmd);
		}
	}

    public sealed class ClickUnitActionFake : ClickUnitEvent.ISubscribed
    {
        public ClickUnitActionFake(IUIManager uiManager)
        {
            
        }

        public void OnEvent(IUnit hit)
        {
            Debug.Log("I am here!!!");
        }
    }
}
