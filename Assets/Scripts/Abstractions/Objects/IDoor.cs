using System;

namespace ShootingBall.Objects
{
    public interface IDoor
    {
        event Action OnPlayerEnteredDoor;
    }
}