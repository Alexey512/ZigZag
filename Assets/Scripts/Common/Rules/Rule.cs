using Assets.Scripts.Common.Actions;

namespace Assets.Scripts.Common.Rules
{
	public class Rule: IRule
	{
		private readonly ICondition _condition;

		private readonly IGameAction _command;

		public Rule(ICondition condition, IGameAction command)
		{
			_condition = condition;
			_command = command;
		}

		public void Execute()
		{
			if (_condition.Evaluate())
				_command.Start();
		}
	}
}
