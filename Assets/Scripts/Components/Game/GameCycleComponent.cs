using ShootingBall.Common;
using ShootingBall.Objects;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Game
{
    public class GameCycleComponent : Component<GameCycle>
    {
        [SerializeField] private DoorComponent _door;
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        [SerializeField] private PlayerSmashedInObstacleHandlerComponent _playerSmashedInObstacleHandler;
        
        protected override GameCycle CreateObject()
        {
            return new GameCycle(_door.Object, _accumulativeShooter.Object,
                _playerSmashedInObstacleHandler.Object);
        }
    }
}