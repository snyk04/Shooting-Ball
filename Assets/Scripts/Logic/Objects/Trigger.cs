using System;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class Trigger : ITrigger
    {
        public event Action<GameObject> OnTrigger;
        
        public void OnTriggerEnter(Collider other)
        {
            OnTrigger?.Invoke(other.gameObject);
        }
    }
}