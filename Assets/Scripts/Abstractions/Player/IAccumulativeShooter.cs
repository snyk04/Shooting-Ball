using System;
using ShootingBall.Objects;

namespace ShootingBall.Player
{
    public interface IAccumulativeShooter
    {
        event Action OnDevastation;
        event Action<IBulletBall> OnAccumulationStarted;
        event Action OnShot;
        
        void StartAccumulating();
        void Shoot();
    }
}