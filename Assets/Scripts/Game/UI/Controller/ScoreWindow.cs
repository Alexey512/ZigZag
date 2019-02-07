using Assets.Scripts.Common.UI.Controller;
using Assets.Scripts.Game.Score;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Game.UI.Controller
{
    public class ScoreWindow : WindowController
    {
        [SerializeField]
        private Text _text;

        private IScoreManager _scoreManager;

        [Inject]
        public new void Construct(IScoreManager scoreManager)
        {
            _scoreManager = scoreManager;
            _scoreManager.ScoreChanged += OnScoreChanged;

            _text.text = _scoreManager.GetScore().ToString();
        }

        private void OnScoreChanged(IScoreManager obj)
        {
            _text.text = _scoreManager.GetScore().ToString();
        }

        public class Factory : PlaceholderFactory<ScoreWindow>
        {
        }
    }
}
