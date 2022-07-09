using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class DoorHandlerComponent : Component<DoorHandler>
    {
        protected override DoorHandler CreateObject()
        {
            return new DoorHandler();
        }

        private void OnTriggerEnter(Collider other)
        {
            Object.OnTriggerEnter(other);
        }
    }
}