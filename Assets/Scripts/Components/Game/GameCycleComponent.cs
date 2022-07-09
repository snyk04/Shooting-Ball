using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Game
{
    public class GameCycleComponent : Component<GameCycle>
    {
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        
        protected override GameCycle CreateObject()
        {
            return new GameCycle(_accumulativeShooter.Object);
        }
    }
}