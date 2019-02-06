using Assets.Scripts.Game.EventSystem;

namespace Assets.Scripts.Common.UI.Context
{
	public class WindowContext: IWindowContext
	{
		public IUIManager UIManager { get; private set; }
		public IEventsManager Publisher { get; private set; }
		public CustomObject Data { get; private set; }

		public WindowContext(IUIManager uiManager, IEventsManager publisher, CustomObject data)
		{
			UIManager = uiManager;
			Publisher = publisher;
			Data = data;
		}
	}
}
