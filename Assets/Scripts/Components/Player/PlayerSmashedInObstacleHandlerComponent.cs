using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Player
{
    public class PlayerSmashedInObstacleHandlerComponent : Component<PlayerSmashedInObstacleHandler>
    {
        protected override PlayerSmashedInObstacleHandler CreateObject()
        {
            return new PlayerSmashedInObstacleHandler();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Object.OnCollisionEnter(collision);
        }
    }
}