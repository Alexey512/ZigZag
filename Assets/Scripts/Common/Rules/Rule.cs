using Assets.Scripts.Common.Commands;

namespace Assets.Scripts.Common.Rules
{
	public class Rule: IRule
	{
		private readonly ICondition _condition;

		private readonly ICommand _command;

		public Rule(ICondition condition, ICommand command)
		{
			_condition = condition;
			_command = command;
		}

		public void Execute()
		{
			if (_condition.Evaluate())
				_command.Execute();
		}
	}
}
