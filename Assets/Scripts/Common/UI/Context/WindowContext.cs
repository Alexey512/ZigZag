using Assets.Scripts.Game.EventSystem;

namespace Assets.Scripts.Common.UI.Context
{
	public class WindowContext: IWindowContext
	{
	    public IEventsManager Publisher { get; private set; }

		public WindowContext(IEventsManager publisher)
		{
			Publisher = publisher;
		}
	}
}
