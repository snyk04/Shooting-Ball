using System;
using System.Threading.Tasks;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class Door : IDoor
    {
        private ITrigger _playerApproachingTrigger;
        private ITrigger _doorwayTrigger;
        
        private readonly Transform _door;
        private readonly Transform _attachmentPoint;

        private readonly int _openedDoorRotationAngle;
        
        public event Action OnPlayerEnteredDoor;

        public Door(ITrigger playerApproachingTrigger, ITrigger playerEnteredDoorwayTrigger, Transform door,
            Transform attachmentPoint, int openedDoorRotationAngle)
        {
            _door = door;
            _attachmentPoint = attachmentPoint;
            _openedDoorRotationAngle = openedDoorRotationAngle;
            
            playerApproachingTrigger.OnTrigger += gameObject =>
            {
                if (ObjectIsPlayer(gameObject))
                {
                    Open();
                }
            };
            playerEnteredDoorwayTrigger.OnTrigger += gameObject =>
            {
                if (ObjectIsPlayer(gameObject))
                {
                    OnPlayerEnteredDoor?.Invoke();
                }
            };
        }
        private bool ObjectIsPlayer(GameObject gameObject)
        {
            return gameObject.TryGetComponent(out PlayerSmashedInObstacleHandlerComponent _);
        }
        
        private async void Open()
        {
            for (int i = 0; i < _openedDoorRotationAngle; i++)
            {
                _door.RotateAround(_attachmentPoint.position, Vector3.up, -1);
                await Task.Yield();
            }
        }
    }
}