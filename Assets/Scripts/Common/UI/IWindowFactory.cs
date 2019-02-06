using Assets.Scripts.Common.UI.Controller;

namespace Assets.Scripts.Common.UI
{
	public interface IWindowFactory 
	{
		T CreateWindow<T>() where T : class, IWindowController;

		//IWindowController CreateWindow(string windowId);
	}
}
