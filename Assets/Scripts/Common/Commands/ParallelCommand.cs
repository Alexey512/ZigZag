using System;

namespace Assets.Scripts.Common.Commands
{
	public class ParallelCommand : CompositeCommand
	{
		private int _completedCount = 0;

		protected override void OnExecute()
		{
			if (_commands.Count == 0)
			{
				Finish();
				return;
			}

			foreach (var cmd in _commands)
			{
				cmd.Complete += OnCommandComplete;
				cmd.Cancelled += OnCommandComplete;
				cmd.Execute();
			}
		}

		private void OnCommandComplete(object sender, EventArgs eventArgs)
		{
			ICommand cmd = sender as ICommand;
			cmd.Complete -= OnCommandComplete;
			_completedCount++;
			if (_completedCount == _commands.Count) { Finish(); }
		}

		protected override void OnTerminate()
		{
			foreach (var cmd in _commands)
			{
				cmd.Complete -= OnCommandComplete;
				cmd.Cancelled -= OnCommandComplete;
				cmd.Terminate();
			}
			_completedCount = 0;
		}
	}
}