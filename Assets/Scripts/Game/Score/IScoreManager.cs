using System;

namespace Assets.Scripts.Game.Score
{
    public interface IScoreManager
    {
        event Action<IScoreManager> ScoreChanged;

        void AddScore(int score);

        int GetScore();

        int GetBestScore();

        int GetLastScore();

        void Finish();

        void Clear();
    }
}
