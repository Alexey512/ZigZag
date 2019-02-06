using System;

namespace Assets.Scripts.Common.Commands
{
	public interface ICommand
	{
		event EventHandler Complete;
		event EventHandler Cancelled;
		bool IsCancelled { get; }
		bool IsComplete { get; }
		void Execute();
		void Terminate();
	}
}