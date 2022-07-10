using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class TriggerComponent : Component<Trigger>
    {
        protected override Trigger CreateObject()
        {
            return new Trigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            Object.OnTriggerEnter(other);
        }
    }
}