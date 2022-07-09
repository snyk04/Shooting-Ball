using System;

namespace ShootingBall.Player
{
    public interface IPlayerSmashedInObstacleHandler
    {
        event Action OnPlayerSmashedInObstacle;
    }
}