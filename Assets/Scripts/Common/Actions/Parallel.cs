namespace Assets.Scripts.Common.Actions
{
    public sealed class Parallel: BaseParallel
    {
        public Parallel(): base(ActionStatus.Failure, ActionStatus.Success)
        {
        }

        public Parallel(params IGameAction[] actions) : base(ActionStatus.Failure, ActionStatus.Success, actions)
        {
        }
    }

    public sealed class ParallelSelector: BaseParallel
    {
        public ParallelSelector() : base(ActionStatus.Success, ActionStatus.Failure)
        {
        }

        public ParallelSelector(params IGameAction[] actions) : base(ActionStatus.Success, ActionStatus.Failure, actions)
        {
        }
    }

    public abstract class BaseParallel: Composite
	{
		private int _completedCount = 0;

	    private readonly ActionStatus _breakStatus;

	    private readonly ActionStatus _returnStatus;

	    protected BaseParallel(ActionStatus breakStatus, ActionStatus returnStatus)
	    {
	        _breakStatus = breakStatus;
	        _returnStatus = returnStatus;
	    }

	    protected BaseParallel(ActionStatus breakStatus, ActionStatus returnStatus, params IGameAction[] actions): base(actions)
		{
		    _breakStatus = breakStatus;
		    _returnStatus = returnStatus;
        }

        protected override void OnAdd(IGameAction item)
		{
			item.Ended += OnComplete;
		}

		protected override void OnRemove(IGameAction item)
		{
			item.Ended -= OnComplete;
		}

		protected override void OnStart()
		{
			if (Count == 0)
			{
				End(/*ActionStatus.Success*/_returnStatus);
				return;
			}

		    _completedCount = 0;
            foreach (var cmd in this)
			{
				cmd.Start();
			}
		}

		private void OnComplete(IGameAction action)
		{
			_completedCount++;
		    if (action.Status == /*ActionStatus.Failure*/_breakStatus)
		    {
		        End(/*ActionStatus.Failure*/_breakStatus);
            }
		    else
		    {
		        if (_completedCount == Count)
		        {
		            End(/*ActionStatus.Success*/_returnStatus);
		        }
		    }
        }

		protected override void OnEnd()
		{
			_completedCount = 0;
		    foreach (var action in this)
		    {
		        action.End(ActionStatus.Inactive);
		    }
		}
	}
}
