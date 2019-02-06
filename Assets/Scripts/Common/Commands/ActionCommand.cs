using System;

namespace Assets.Scripts.Common.Commands
{
	public class ActionCommand : Command
	{
		private readonly Action _action;

		public ActionCommand(Action action)
		{
			_action = action;
		}

		protected override void OnExecute()
		{
			if (_action != null)
				_action.Invoke();

			Finish();
		}

		protected override void OnTerminate() { }
	}
}