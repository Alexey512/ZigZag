using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Common.UI.Controller;
using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.Score;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Game.UI.Controller
{
    public class StartWindow: WindowController
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Text _textScore;

        private IScoreManager _scoreManager;

        [Inject]
        public new void Construct(IScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
        }

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

        protected override void OnShow()
        {
            int best = _scoreManager.GetBestScore();
            int last = _scoreManager.GetLastScore();

            _textScore.text = $"Last Score: {last}   Best Score: {best}";
        }

        public class Factory : PlaceholderFactory<StartWindow>
        {
        }
    }
}
