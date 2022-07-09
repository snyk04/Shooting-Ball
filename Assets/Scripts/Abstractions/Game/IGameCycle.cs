using System;

namespace ShootingBall.Game
{
    public interface IGameCycle
    {
        event Action OnGameStart;
        event Action<GameEndType> OnGameEnd;

        void StartGame();
    }
}