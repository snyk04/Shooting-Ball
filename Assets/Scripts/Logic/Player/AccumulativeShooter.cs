using UnityEngine;

namespace ShootingBall.Player
{
    public class AccumulativeShooter : IAccumulativeShooter
    {
        public void StartAccumulating()
        {
            Debug.Log("Accumulation started!");
        }

        public void Shoot()
        {
            Debug.Log("Accumulation ended!");
        }
    }
}