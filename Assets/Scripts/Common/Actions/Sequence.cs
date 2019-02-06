using System.Collections.Generic;

namespace Assets.Scripts.Common.Actions
{
    public sealed class Sequence: BaseSequence
    {
        public Sequence() : base(ActionStatus.Failure, ActionStatus.Success)
        {
        }

        public Sequence(params IGameAction[] actions) : base(ActionStatus.Failure, ActionStatus.Success, actions)
        {
        }
    }

    public sealed class Selector : BaseSequence
    {
        public Selector() : base(ActionStatus.Success, ActionStatus.Failure)
        {
        }

        public Selector(params IGameAction[] actions) : base(ActionStatus.Success, ActionStatus.Failure, actions)
        {
        }
    }

    public abstract class BaseSequence: Composite
    {
        private IEnumerator<IGameAction> _enumerator;

        private readonly ActionStatus _breakStatus;

        private readonly ActionStatus _returnStatus;

        protected BaseSequence(ActionStatus breakStatus, ActionStatus returnStatus)
        {
            _breakStatus = breakStatus;
            _returnStatus = returnStatus;
        }

        protected BaseSequence(ActionStatus breakStatus, ActionStatus returnStatus, params IGameAction[] actions): base(actions)
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
		    _enumerator?.Dispose();
            _enumerator = GetEnumerator();
		    _enumerator.Reset();
		    if (!_enumerator.MoveNext())
		    {
                End(/*ActionStatus.Success*/_returnStatus);
                return;
		    }

		    _enumerator.Current?.Start();
		}

        private void OnComplete(IGameAction action)
        {
            if (action.Status == /*ActionStatus.Failure*/_breakStatus)
            {
                End(/*ActionStatus.Failure*/_breakStatus);
                return;
            }

            if (_enumerator == null || !_enumerator.MoveNext())
            {
                End(/*ActionStatus.Success*/_returnStatus);
                return;
            }

            _enumerator.Current?.Start();
        }

        protected override void OnEnd()
        {
            _enumerator.Dispose();
            _enumerator = null;
            foreach (var child in this)
            {
                child.End(ActionStatus.Inactive);
            }
        }
	}
}
