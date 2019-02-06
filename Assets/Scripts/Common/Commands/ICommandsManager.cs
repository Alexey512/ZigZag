using System;

namespace Assets.Scripts.Common.Commands
{
	public interface ICommandsManager
	{
		void ExecuteCommand(ICommand command, Action<ICommand> completeAction = null);

		void TerminateCommand(ICommand command);
	}
}