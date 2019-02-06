using System;

namespace Assets.Scripts.Common.Commands
{
	public class SequenceCommand : CompositeCommand
	{
		private ICommand _currentActive = null;
		private int _currentActiveIndex = -1;

		public SequenceCommand() { }

		public SequenceCommand(params ICommand[] commands)
		{
			_commands.AddRange(commands);
		}

		protected override void OnExecute()
		{
			MoveNextCommand();
			if (_currentActive != null)
			{
				_currentActive.Complete += OnCommandComplete;
				_currentActive.Cancelled += OnCommandComplete;
				_currentActive.Execute();
			}
			else { Finish(); }
		}

		private void MoveNextCommand()
		{
			_currentActiveIndex++;
			if (_currentActiveIndex >= _commands.Count)
			{
				_currentActiveIndex = -1;
				_currentActive = null;
				return;
			}

			_currentActive = _commands[_currentActiveIndex];
			if (_currentActive.IsComplete || _currentActive.IsCancelled)
				MoveNextCommand();
		}

		private void OnCommandComplete(object sender, EventArgs e)
		{
			ICommand command = sender as ICommand;
			command.Complete -= OnCommandComplete;
			command.Cancelled -= OnCommandComplete;
			MoveNextCommand();
			if (_currentActive == null) { Finish(); }
			else
			{
				_currentActive.Complete += OnCommandComplete;
				_currentActive.Cancelled += OnCommandComplete;
				_currentActive.Execute();
			}
		}

		protected override void OnTerminate()
		{
			if (_currentActive != null)
			{
				//_currentActive.Terminate();
				//_currentActive.Complete -= OnCommandComplete;
				//_currentActive.Cancelled -= OnCommandComplete;
				_currentActive = null;
			}

			foreach (var command in _commands)
			{
				command.Complete -= OnCommandComplete;
				command.Cancelled -= OnCommandComplete;
				command.Terminate();
			}

			_commands.Clear();

			_currentActiveIndex = -1;
		}
	}
}