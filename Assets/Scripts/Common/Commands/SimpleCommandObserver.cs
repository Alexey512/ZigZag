using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Assets.Scripts.Common.Commands
{
	public class SimpleCommandObserver
	{
		private List<ICommand> _commands = new List<ICommand>();

		private bool _isStarted;
		private bool _isComplete;

		private Action _onAllComplete;

		public void Add(ICommand command)
		{
			Assert.IsFalse(_isStarted);
			Assert.IsFalse(_isComplete);
			Assert.IsFalse(_commands.Contains(command));

			if (command.IsComplete || command.IsCancelled)
				return;

			_commands.Add(command);
		}

		public void StartObserve(Action callback)
		{
			Assert.IsFalse(_isStarted);
			Assert.IsFalse(_isComplete);

			_isStarted = true;

			_commands = _commands.Where(c => !c.IsComplete && !c.IsCancelled).ToList();

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
			Assert.IsTrue(_isStarted);
			Assert.IsFalse(_isComplete);

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