using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Game
{
    public class GameCycleComponent : Component<GameCycle>
    {
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        [SerializeField] private PlayerSmashedInObstacleHandlerComponent _playerSmashedInObstacleHandler;
        
        protected override GameCycle CreateObject()
        {
            return new GameCycle(_accumulativeShooter.Object, _playerSmashedInObstacleHandler.Object);
        }

        private void Start()
        {
            Object.StartGame();
        }
    }
}