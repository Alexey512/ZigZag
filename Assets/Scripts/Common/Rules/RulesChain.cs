using System.Collections.Generic;

namespace Assets.Scripts.Common.Rules
{
	public class RulesChain: IRule
	{
		private readonly List<IRule> _rules = new List<IRule>();

		public RulesChain(params IRule[] rules)
		{
			_rules.AddRange(rules);
		}

		public void Execute()
		{
			foreach (var rule in _rules)
			{
				rule.Execute();
			}
		}
	}
}
