using System;
using Assets.Scripts.Common.Actions;
using Game.Actions;

namespace Game.Objects.Logic
{
	/*public class ConditionAction: GameAction
	{
		private readonly Func<ActionContext, bool> _condition;
		public readonly IGameAction IfAction;
		public readonly IGameAction ElseAction;

		public ConditionAction(Func<ActionContext, bool> condition, IGameAction ifAction, IGameAction elseAction = null)
		{
			_condition = condition;
			IfAction = ifAction;
			ElseAction = elseAction;
		}

		protected override void OnStart()
		{
			//if (_condition.Invoke(ActionContext))
			//{
			//	IfAction.Ended += OnActionEnd;
			//	IfAction.Stoped += OnActionEnd;
			//	IfAction.Start();
			//}
			//else
			//{
			//	End();
			//}
		}

		private void OnActionEnd(IGameAction obj)
		{
			//IfAction.Ended -= OnActionEnd;
			//IfAction.Stoped -= OnActionEnd;

			//End();
		}

		protected override void OnStop()
		{
			//IfAction?.Stop();
			//ElseAction?.Stop();
		}
	}*/
}
