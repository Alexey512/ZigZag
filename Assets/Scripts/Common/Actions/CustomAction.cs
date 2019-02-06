using System;
using Game.Objects.Logic;

namespace Game.Objects.Logics
{
	/*public class CustomActionExt: LogicAction
	{
		private readonly Action<LogicAction> _action;

		public CustomActionExt(Action<LogicAction> action)
		{
			_action = action;
		}
		protected override void OnStart()
		{
			_action?.Invoke(this);
		}
	}

	public class CustomAction: LogicAction
	{
		private readonly Action<LogicContext> _action;

		private readonly Func<LogicContext, bool> _condition;

		public CustomAction(Action<LogicContext> action)
		{
			_action = action;
		}

		public CustomAction(Func<LogicContext, bool> condition, Action<LogicContext> action)
		{
			_action = action;
			_condition = condition;
		}

		protected override void OnStart()
		{
			if (_condition == null || _condition.Invoke(ActionContext))
			{
				_action?.Invoke(ActionContext);
				End();
			}
			else
			{
				StartUpdate();
			}
		}

		protected override void OnUpdate()
		{
			if (_condition.Invoke(ActionContext))
			{
				_action?.Invoke(ActionContext);
				End();
			}
		}
	}*/
}
