using System;

namespace Assets.Scripts.Common.Commands
{
	public abstract class Command : ICommand
	{
		public event EventHandler Complete;
		public event EventHandler Cancelled;

		public string CommandKey
		{
			get { return GetType().Name; }
		}

		public bool IsComplete => _isComplete;
		public bool IsCancelled => _isCancelled;

		protected bool _isExecute;
		protected bool _isComplete;
		protected bool _isCancelled;

		public bool IsExecute
		{
			get { return _isExecute; }
		}

		public void Execute()
		{
			if (_isExecute) return;
			_isExecute = true;
			OnExecute();
		}

		public void Terminate()
		{
			if (!_isComplete) _isCancelled = true;

			if (!_isExecute) return;
			_isExecute = false;
			OnTerminate();

			var handler = Cancelled;
			handler?.Invoke(this, EventArgs.Empty);
		}

		protected virtual void Finish()
		{
			if (!_isCancelled) _isComplete = true;

			if (!_isExecute) return;
			_isExecute = false;

			OnComplete();

			var handler = Complete;
			handler?.Invoke(this, EventArgs.Empty);
		}

		protected abstract void OnExecute();

		protected abstract void OnTerminate();

		protected virtual void OnComplete() { }
	}
}