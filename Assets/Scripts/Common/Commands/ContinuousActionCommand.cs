using System;

namespace Assets.Scripts.Common.Commands
{
	public class ContinuousActionCommand<TResult> : Command
	{
		private Action<Action<TResult>> _action;
		private Action<TResult> _postAction;

		public ContinuousActionCommand(Action<Action<TResult>> action, Action<TResult> postAction)
		{
			_action = action;
			_postAction = postAction;
		}

		protected override void OnExecute()
		{
			_action.Invoke(OnActionComplete);
		}

		private void OnActionComplete(TResult c)
		{
			if (!IsExecute) return;
			_action = null;
			var callback = _postAction;
			_postAction = null;
			callback?.Invoke(c);

			Finish();
		}

		protected override void OnTerminate()
		{
			_action = null;
			_postAction = null;
		}
	}
}