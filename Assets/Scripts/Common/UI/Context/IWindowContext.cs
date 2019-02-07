using Assets.Scripts.Game.EventSystem;

namespace Assets.Scripts.Common.UI.Context
{
	public interface IWindowContext
	{
	    IEventsManager Publisher { get; }
	}
}
