using Assets.Scripts.Common.Actions;
using Game.Actions;

namespace Game.Objects.Logic
{
	public class LoopAction: GameAction
	{
		private readonly IGameAction _owner;

		public IGameAction Owner => _owner;

		private readonly int _loopsCount;

		private int _leftCount;

		/*public override LogicContext ActionContext
		{
			get { return base.ActionContext; }
			set
			{
				base.ActionContext = value;
				if (_owner != null)
					_owner.ActionContext = value;
			}
		}*/

		public LoopAction(IGameAction owner, int loopsCount = -1)
		{
			_owner = owner;
			_loopsCount = loopsCount;
		}

		protected override void OnStart()
		{
			_leftCount = _loopsCount;
			_owner.Ended += OnCommandComplete;
			_owner.Start();
		}

		private void OnCommandComplete(IGameAction action)
		{
		    if (action.Status == ActionStatus.Failure)
		    {
		        End(ActionStatus.Failure);
                return;
		    }

            if (_loopsCount < 0)
			{
				_owner.Start();
				return;
			}

			_leftCount--;
			if (_leftCount < 0)
			{
				End(ActionStatus.Success);
			}
			else
			{
			    _owner.Start();
			}
        }

		protected override void OnEnd()
		{
			_owner.Ended -= OnCommandComplete;
		}
	}
}
