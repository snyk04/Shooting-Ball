using ShootingBall.Common;
using ShootingBall.Game;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Input
{
    public class PlayerInputComponent : Component<PlayerInput>
    {
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        [SerializeField] private GameCycleComponent _gameCycle;

        protected override PlayerInput CreateObject()
        {
            return new PlayerInput(_accumulativeShooter.Object, _gameCycle.Object);
        }
    }
}