using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class BulletBallComponent : Component<BulletBall>
    {
        protected override BulletBall CreateObject()
        {
            return new BulletBall(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Object.OnCollisionEnter(collision);
        }
    }
}