
using Assets.Scripts.Game.Model;

namespace Assets.Scripts.Game.Events
{
	public sealed class SetInputStateAction: SetInputStateEvent.ISubscribed
	{
		private readonly IGameScene _gameScene;

		public SetInputStateAction(IGameScene gameScene)
		{
			_gameScene = gameScene;
		}

		public void OnEvent(eInputState hit)
		{
			_gameScene.InputState = hit;
		}
	}
}
