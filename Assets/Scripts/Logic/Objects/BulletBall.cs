using System;
using ShootingBall.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Objects
{
    public class BulletBall : IBulletBall
    {
        private readonly GameObject _gameObject;
        private readonly float _maxInfestRadius;

        private float _power;

        public event Action OnHit;

        public BulletBall(GameObject gameObject, float maxInfestRadius)
        {
            _gameObject = gameObject;
            _maxInfestRadius = maxInfestRadius;
        }
        
        public void IncreasePower(float value)
        {
            _power += value;
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
            Object.Destroy(_gameObject);
        }
        private void InfestNearbyObstacles(Vector3 position)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(position, _power * _maxInfestRadius);
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