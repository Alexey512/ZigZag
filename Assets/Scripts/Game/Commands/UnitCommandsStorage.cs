using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;

namespace Assets.Scripts.Game.Commands
{
	public class UnitCommandsStorage: IUnitCommandsStorage
	{
		private readonly Dictionary<IUnit, List<ICommand>> _commands = new Dictionary<IUnit, List<ICommand>>();

		public void ExecuteCommand(IUnit unit, ICommand command)
		{
			List<ICommand> commands;
			if (!_commands.TryGetValue(unit, out commands))
			{
				commands = new List<ICommand>();
				_commands[unit] = commands;
			}
			commands.Add(command);
			command.Complete += (sender, args) => { commands.Remove(command); };
			command.Cancelled += (sender, args) => { commands.Remove(command); };
			command.Execute();
		}

		public void TerminateCommand(IUnit unit)
		{
			List<ICommand> commands;
			if (!_commands.TryGetValue(unit, out commands))
				return;
			for (int i = commands.Count - 1; i >= 0; i--)
			{
				commands[i].Terminate();
			}
			//commands.ForEach(c => c.Terminate());
			_commands.Remove(unit);
		}
	}
}
