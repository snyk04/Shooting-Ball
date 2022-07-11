using System;

namespace ShootingBall.Objects
{
    public interface IBulletBall
    {
        float Power { get; }
        
        event Action OnHit;

        void IncreasePower(float value);
    }
}