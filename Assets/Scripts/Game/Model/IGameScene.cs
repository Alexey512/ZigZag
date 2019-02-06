using System.Collections.Generic;
using Assets.Scripts.Game.Units;

namespace Assets.Scripts.Game.Model
{
	public enum eInputState
	{
		None,
		Create,
		Move,
		Attack,
	}

	public interface IGameScene
	{
	    GameField Field { get; }

        eInputState InputState { get; set; }

		List<IUnit> Units { get; }

		IUnit SelectedUnit { get; set; }
	}
}
