using System;

namespace ShootingBall.Objects
{
    public interface IDoorHandler
    {
        event Action OnPlayerEnteredDoor;
    }
}