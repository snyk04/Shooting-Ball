using ShootingBall.Common;

namespace ShootingBall.Player
{
    public class AccumulativeShooterComponent : Component<AccumulativeShooter>
    {
        protected override AccumulativeShooter CreateObject()
        {
            return new AccumulativeShooter();
        }
    }
}