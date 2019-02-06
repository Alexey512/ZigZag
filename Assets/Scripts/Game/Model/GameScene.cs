using System.Collections.Generic;
using Assets.Scripts.Game.Units;

namespace Assets.Scripts.Game.Model
{
	public sealed class GameScene: IGameScene
	{
	    private readonly GameField _field;

	    public GameField Field => _field;

	    public GameScene(GameField field)
	    {
	        _field = field;
	    }

        public eInputState InputState { get; set; }

		public List<IUnit> Units { get; private set; } = new List<IUnit>();

		public IUnit SelectedUnit { get; set; }
	}
}
