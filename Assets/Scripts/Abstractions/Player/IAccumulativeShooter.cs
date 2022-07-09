using System;

namespace ShootingBall.Player
{
    public interface IAccumulativeShooter
    {
        event Action OnDevastation;
        
        void StartAccumulating();
        void Shoot();
    }
}