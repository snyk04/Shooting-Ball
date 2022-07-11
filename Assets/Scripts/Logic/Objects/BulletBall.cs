using System;
using ShootingBall.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Objects
{
    public class BulletBall : IBulletBall
    {
        private readonly GameObject _ballObject;
        private readonly float _infestRadiusRatio;

        public float Power { get; private set; }

        public event Action OnHit;

        public BulletBall(GameObject ballObject, float infestRadiusRatio)
        {
            _ballObject = ballObject;
            _infestRadiusRatio = infestRadiusRatio;
        }
        
        public void IncreasePower(float value)
        {
            Power += value;
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out PlayerSmashedInObstacleHandlerComponent _))
            {
                return;
            }
            
            if (collision.collider.TryGetComponent(out ObstacleComponent _))
            {
                InfestNearbyObstacles(collision.transform.position);
            }
            
            OnHit?.Invoke();
            Object.Destroy(_ballObject);
        }
        private void InfestNearbyObstacles(Vector3 position)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(position, Power * _infestRadiusRatio);
            foreach (Collider collider in nearbyColliders)
            {
                if (collider.TryGetComponent(out ObstacleComponent obstacleComponent))
                {
                    IObstacle obstacle = obstacleComponent.Object;
                    obstacle.Infest();
                }
            }
        }
    }
}