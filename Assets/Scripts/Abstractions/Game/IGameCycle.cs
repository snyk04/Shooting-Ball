using System;

namespace ShootingBall.Game
{
    public interface IGameCycle
    {
        event Action<GameEndType> OnGameEnd;
    }
}