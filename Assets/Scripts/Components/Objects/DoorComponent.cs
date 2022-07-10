using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class DoorComponent : Component<Door>
    {
        [Header("References")] 
        [SerializeField] private TriggerComponent _playerApproachingTrigger;
        [SerializeField] private TriggerComponent _doorwayTrigger;
        
        [Header("Objects")]
        [SerializeField] private Transform _door;
        [SerializeField] private Transform _attachmentPoint;

        [Header("Settings")] 
        [SerializeField] private int _openedDoorRotationAngle;
        
        protected override Door CreateObject()
        {
            return new Door(_playerApproachingTrigger.Object, _doorwayTrigger.Object, _door,
                _attachmentPoint, _openedDoorRotationAngle);
        }
    }
}