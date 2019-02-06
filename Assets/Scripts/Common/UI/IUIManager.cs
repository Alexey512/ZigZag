using Assets.Scripts.Common.UI.Controller;

namespace Assets.Scripts.Common.UI
{
	public interface IUIManager
	{
		void ShowWindow<T>(CustomObject data) where T : class, IWindowController;
	}
}
