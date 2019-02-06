using System;
using System.Collections.Generic;

namespace Assets.Scripts.Common.Commands
{
	public class CommandsManager : ICommandsManager
	{
		private readonly Dictionary<ICommand, Action<ICommand>> _executeCommands =
			new Dictionary<ICommand, Action<ICommand>>();

		public void ExecuteCommand(ICommand command, Action<ICommand> completeAction = null)
		{
			_executeCommands.Add(command, completeAction);
			command.Complete += OnCommandComplete;
			command.Execute();
		}

		private void OnCommandComplete(object sender, EventArgs eventArgs)
		{
			ICommand cmd = sender as ICommand;
			cmd.Complete -= OnCommandComplete;
			var handler = _executeCommands[cmd];
			if (handler != null)
				handler.Invoke(cmd);
			_executeCommands.Remove(cmd);
		}

		public void TerminateCommand(ICommand command)
		{
			command.Complete -= OnCommandComplete;
			command.Terminate();
			_executeCommands.Remove(command);
		}
	}
}