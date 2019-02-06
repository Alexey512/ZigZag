using System;

namespace Assets.Scripts.Common.Commands
{
	public class WaitOtherCommand : Command
	{
		private ICommand _otherCommand;

		public WaitOtherCommand(ICommand otherCommand)
		{
			_otherCommand = otherCommand;
		}

		protected override void OnExecute()
		{
			if (_otherCommand == null || _otherCommand.IsComplete || _otherCommand.IsCancelled)
				Finish();
			else
				StartListenOtherCommand();
		}

		protected override void OnComplete()
		{
			StopListenOtherCommand();
			_otherCommand = null;
		}

		protected override void OnTerminate()
		{
			StopListenOtherCommand();
			_otherCommand = null;
		}

		private void OnOtherCommandFinished(object sender, EventArgs e)
		{
			Finish();
		}

		private void StartListenOtherCommand()
		{
			if (_otherCommand == null)
				return;

			_otherCommand.Complete += OnOtherCommandFinished;
			_otherCommand.Cancelled += OnOtherCommandFinished;
		}

		private void StopListenOtherCommand()
		{
			if (_otherCommand == null)
				return;

			_otherCommand.Complete -= OnOtherCommandFinished;
			_otherCommand.Cancelled -= OnOtherCommandFinished;
		}
	}
}