using System;
using ShootingBall.Objects;

namespace ShootingBall.Player
{
    public interface IAccumulativeShooter
    {
        event Action<IBulletBall> OnAccumulationStarted;
        event Action OnShot;
        event Action OnDevastation;
        
        void StartAccumulating();
        void Shoot();
    }
}