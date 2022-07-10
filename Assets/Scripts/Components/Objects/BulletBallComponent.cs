using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class BulletBallComponent : Component<BulletBall>
    {
        [SerializeField] private float _maxInfestRadius;
        
        protected override BulletBall CreateObject()
        {
            return new BulletBall(gameObject, _maxInfestRadius);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Object.OnCollisionEnter(collision);
        }
    }
}