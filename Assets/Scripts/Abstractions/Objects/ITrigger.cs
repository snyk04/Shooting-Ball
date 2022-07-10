using System;
using UnityEngine;

namespace ShootingBall.Objects
{
    public interface ITrigger
    {
        event Action<GameObject> OnTrigger;
    }
}