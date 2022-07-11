using System;

namespace ShootingBall.Objects
{
    public interface IBulletBall
    {
        event Action OnHit; 

        void IncreasePower(float value);
    }
}