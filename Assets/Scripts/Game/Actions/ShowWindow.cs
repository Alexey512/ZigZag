using Assets.Scripts.Common;
using Assets.Scripts.Common.Actions;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.UI.Controller;

namespace Assets.Scripts.Game.Actions
{
    public class ShowWindow<T> : GameTask where T : class, IWindowController
    {
        private IUIManager _uiManager;

        private CustomObject _data;

        public ShowWindow(IUIManager uiManager, CustomObject data)
        {
            _uiManager = uiManager;
            _data = data;
        }

        protected override void OnStart()
        {
            _uiManager.ShowWindow<T>(_data);
            End(ActionStatus.Success);
        }
    }
}
