using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Common.Commands
{
	public class CommandsObserver
	{
		private List<ICommand> _commands = new List<ICommand>();

		private bool _isStarted;
		private bool _isComplete;

		private Action _onAllComplete;

		public int Count => _commands.Count;

		public CommandsObserver(params ICommand[] commands)
		{
			_commands.AddRange(commands);
		}

		public void Add(ICommand command)
		{
			if (_isStarted || command.IsComplete || command.IsCancelled)
				return;

			_commands.Add(command);
		}

		public void StartObserve(Action callback)
		{
			if (_isStarted || _isComplete)
				return;
			_isStarted = true;

			_commands = _commands.Where(c => !c.IsCancelled && !c.IsComplete).ToList();

			if (_commands.Count == 0)
			{
				callback.Invoke();
				return;
			}

			_onAllComplete = callback;

			foreach (var command in _commands)
			{
				command.Complete += OnCommandFinished;
				command.Cancelled += OnCommandFinished;
			}
		}

		public void Stop()
		{
			if (!_isStarted || _isComplete)
				return;
			_isStarted = false;
			foreach (var command in _commands)
			{
				command.Complete -= OnCommandFinished;
				command.Cancelled -= OnCommandFinished;
			}

			_commands.Clear();

			_onAllComplete = null;
			_isComplete = true;
		}

		private void OnCommandFinished(object sender, EventArgs e)
		{
			var command = (ICommand)sender;
			command.Complete -= OnCommandFinished;
			command.Cancelled -= OnCommandFinished;

			_commands.Remove(command);

			if (_commands.Count == 0)
			{
				_isComplete = true;

				var callback = _onAllComplete;
				Stop();
				callback?.Invoke();
			}
		}
	}
}