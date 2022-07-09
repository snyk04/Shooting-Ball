namespace ShootingBall.Objects
{
    public interface IBulletBall
    {
        float Power { get; }

        void IncreasePower(float value);
    }
}