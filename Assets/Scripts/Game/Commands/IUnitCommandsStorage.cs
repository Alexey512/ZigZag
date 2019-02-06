
using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;

namespace Assets.Scripts.Game.Commands
{
	public interface IUnitCommandsStorage
	{
		void ExecuteCommand(IUnit unit, ICommand command);

		void TerminateCommand(IUnit unit);
	}
}
