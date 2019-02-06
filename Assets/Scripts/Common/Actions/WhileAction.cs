using System;
using Game.Actions;
using Game.Objects.Logic;

namespace Game.Objects.Logics
{
	/*public class WhileAction : LogicAction
	{
		private readonly IGameActionExt _owner;

		public IGameActionExt Owner => _owner;

		private readonly Func<LogicContext, bool> _condition;

		public WhileAction(Func<LogicContext, bool> condition, IGameActionExt owner)
		{
			_condition = condition;
			_owner = owner;
		}

		protected override void OnStart()
		{
			if (!_condition.Invoke(ActionContext))
			{
				End();
				return;
			}

			_owner.Ended += OnCommandComplete;
			_owner.Stoped += OnCommandComplete;
			_owner.Start();
		}

		private void OnCommandComplete(IGameActionExt action)
		{
			if (!_condition.Invoke(ActionContext))
			{
				End();
				return;
			}

			_owner.Start();
		}

		protected override void OnEnd()
		{
			_owner.Ended -= OnCommandComplete;
			_owner.Stoped -= OnCommandComplete;
		}

		protected override void OnStop()
		{
			_owner.Ended -= OnCommandComplete;
			_owner.Stoped -= OnCommandComplete;
			_owner.Stop();
		}
	}*/
}
