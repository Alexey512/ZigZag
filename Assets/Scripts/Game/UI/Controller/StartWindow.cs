using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Common.UI.Controller;
using Assets.Scripts.Game.Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Game.UI.Controller
{
    public class StartWindow: WindowController
    {
        [SerializeField]
        private Button _startButton;

        protected override void OnCreate()
        {
            _startButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Context.Publisher.PublishEvent(new CreateGameEvent());
            Context.Publisher.PublishEvent(new StartGameEvent());

            Hide();
        }

        public class Factory : PlaceholderFactory<StartWindow>
        {
        }
    }
}
