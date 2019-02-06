using System;

namespace Assets.Scripts.Common.Commands
{
	public class LoopCommand: Command
	{
		private readonly ICommand _owner;

		private readonly int _loopsCount;

		private int _leftCount;

		public LoopCommand(ICommand owner, int loopsCount = -1)
		{
			_owner = owner;
			_loopsCount = loopsCount;
		}

		protected override void OnExecute()
		{
			if (_owner == null)
			{
				Finish();
				return;
			}

			_leftCount = _loopsCount;
			_owner.Complete += OnCommandComplete;
			_owner.Cancelled += OnCommandComplete;
			_owner.Execute();
		}

		private void OnCommandComplete(object sender, EventArgs eventArgs)
		{
			if (_loopsCount < 0)
			{
				_owner.Execute();
				return;
			}

			_leftCount--;
			if (_leftCount < 0)
			{
				Finish();
			}
		}

		protected override void OnTerminate()
		{
			if (_owner == null)
				return;
			_owner.Complete -= OnCommandComplete;
			_owner.Cancelled -= OnCommandComplete;
			_owner.Terminate();
		}
	}
}
