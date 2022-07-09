using System;
using ShootingBall.Player;

namespace ShootingBall.Game
{
    public class GameCycle : IGameCycle
    {
        public event Action<GameEndType> OnGameEnd;

        public GameCycle(IAccumulativeShooter accumulativeShooter)
        {
            accumulativeShooter.OnDevastation += HandleGameOver;
        }

        private void HandleVictory()
        {
            OnGameEnd?.Invoke(GameEndType.Victory);
        }
        private void HandleGameOver()
        {
            OnGameEnd?.Invoke(GameEndType.GameOver);
        }
    }
}