using System;
using ShootingBall.Objects;
using UnityEngine;

namespace ShootingBall.Player
{
    public class PlayerSmashedInObstacleHandler : IPlayerSmashedInObstacleHandler
    {
        public event Action OnPlayerSmashedInObstacle;
        
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out ObstacleComponent _))
            {
                OnPlayerSmashedInObstacle?.Invoke();
            }
        }
    }
}