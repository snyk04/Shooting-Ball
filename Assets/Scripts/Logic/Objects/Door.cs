using System;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class Door : IDoor
    {
        public event Action OnPlayerEnteredDoor;

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerSmashedInObstacleHandlerComponent _))
            {
                OnPlayerEnteredDoor?.Invoke();
            }
        }
    }
}