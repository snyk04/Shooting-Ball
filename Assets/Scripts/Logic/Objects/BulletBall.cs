using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Objects
{
    public class BulletBall : IBulletBall
    {
        public float Power { get; private set; }

        private readonly GameObject _gameObject;
        private readonly float _maxInfestRadius;

        public BulletBall(GameObject gameObject, float maxInfestRadius)
        {
            _gameObject = gameObject;
            _maxInfestRadius = maxInfestRadius;
        }
        
        public void IncreasePower(float value)
        {
            Power += value;
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent(out ObstacleComponent _))
            {
                return;
            }

            InfestNearbyObstacles(collision.transform.position);
            
            Object.Destroy(_gameObject);
        }
        private void InfestNearbyObstacles(Vector3 position)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(position, Power * _maxInfestRadius);
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