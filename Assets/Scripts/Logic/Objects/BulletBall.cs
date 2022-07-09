using UnityEngine;

namespace ShootingBall.Objects
{
    public class BulletBall : IBulletBall
    {
        // TODO : Remove
        private const float InfestRadius = 3;
        
        public float Power { get; private set; }

        private readonly GameObject _gameObject;

        public BulletBall(GameObject gameObject)
        {
            // TODO : Remove
            Power = 1;

            _gameObject = gameObject;
        }
        
        public void IncreasePower(float value)
        {
            Power += value;
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            if (!ColliderIsObstacle(collision.collider, out ObstacleComponent _))
            {
                return;
            }

            InfestNearbyObstacles(collision.transform.position);
            
            Object.Destroy(_gameObject);
        }

        private void InfestNearbyObstacles(Vector3 position)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(position, InfestRadius);
            foreach (Collider collider in nearbyColliders)
            {
                if (ColliderIsObstacle(collider, out ObstacleComponent obstacleComponent))
                {
                    IObstacle obstacle = obstacleComponent.Object;
                    obstacle.Infest();
                }
            }
        }

        private bool ColliderIsObstacle(Component collider, out ObstacleComponent obstacleComponent)
        {
            return collider.TryGetComponent(out obstacleComponent);
        }
    }
}