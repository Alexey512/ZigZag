using System;

namespace Assets.Scripts.Game.Score
{
    public class ScoreManager: IScoreManager
    {
        public event Action<IScoreManager> ScoreChanged;

        private int _curScore;

        private int _bestScore;

        public void AddScore(int score)
        {
            _curScore += score;
            ScoreChanged?.Invoke(this);
        }

        public int GetScore()
        {
            return _curScore;
        }

        public int GetBestScore()
        {
            return _bestScore;
        }

        public void Finish()
        {
            if (_curScore > _bestScore)
            {
                _bestScore = _curScore;
            }

            _curScore = 0;
            ScoreChanged?.Invoke(this);
        }

        public void Clear()
        {
            _curScore = 0;
            ScoreChanged?.Invoke(this);
        }
    }
}
