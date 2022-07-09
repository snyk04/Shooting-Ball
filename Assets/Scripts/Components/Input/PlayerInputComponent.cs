using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Input
{
    public class PlayerInputComponent : Component<PlayerInput>
    {
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;

        protected override PlayerInput CreateObject()
        {
            return new PlayerInput(_accumulativeShooter.Object);
        }
    }
}