using Assets.Scripts.Game.EventSystem;

namespace Assets.Scripts.Common.UI.Context
{
	public interface IWindowContext
	{
		IUIManager UIManager { get; }

	    IEventsManager Publisher { get; }

		CustomObject Data { get; }
	}
}
