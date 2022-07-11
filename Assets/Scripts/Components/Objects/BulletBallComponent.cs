using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class BulletBallComponent : Component<BulletBall>
    {
        [SerializeField] private float _infestRadiusRatio;
        
        protected override BulletBall CreateObject()
        {
            return new BulletBall(gameObject, _infestRadiusRatio);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Object.OnCollisionEnter(collision);
        }
    }
}