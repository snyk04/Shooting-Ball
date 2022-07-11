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

        private readonly float _openingLength;
        
        public event Action OnPlayerEnteredDoor;

        public Door(ITrigger playerApproachingTrigger, ITrigger playerEnteredDoorwayTrigger, Transform door,
            Transform attachmentPoint, int openedDoorRotationAngle, float openingLength)
        {
            _door = door;
            _attachmentPoint = attachmentPoint;
            _openedDoorRotationAngle = openedDoorRotationAngle;
            _openingLength = openingLength;
            
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
        
        private void Open()
        {
            _door.RotateAround(_attachmentPoint.position, Vector3.up, -_openedDoorRotationAngle);
        }
    }
}