using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class DoorComponent : Component<Door>
    {
        protected override Door CreateObject()
        {
            return new Door();
        }

        private void OnTriggerEnter(Collider other)
        {
            Object.OnTriggerEnter(other);
        }
    }
}