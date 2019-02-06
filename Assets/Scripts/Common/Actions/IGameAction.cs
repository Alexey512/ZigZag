using System;

namespace Assets.Scripts.Common.Actions
{
	public interface IUpdatable
	{
		void Update(float delta);
	}

    public enum ActionStatus
    {
        Inactive = 0,
        Failure = 1,
        Success = 2,
        Running = 3
    }

    public interface IGameAction
	{
		event Action<IGameAction> Started;

		event Action<IGameAction> Ended;

		void Start();

		void End(ActionStatus status);

	    void Update();

	    ActionStatus Status { get; }
    }
}
