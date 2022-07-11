using ShootingBall.Objects;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class AccumulativeShooterVoiceOver : VoiceOver
    {
        private readonly AudioClip _accumulateSound;
        private readonly AudioClip _hitSound;

        public AccumulativeShooterVoiceOver(AudioSource audioSource, IAccumulativeShooter accumulativeShooter,
            AudioClip accumulateSound, AudioClip shotSound, AudioClip hitSound, AudioClip devastationSound) : base(
            audioSource)
        {
            accumulativeShooter.OnAccumulationStarted += HandleAccumulationStarted;
            accumulativeShooter.OnShot += () => PlaySound(shotSound);
            accumulativeShooter.OnDevastation += () => PlaySound(devastationSound);

            _accumulateSound = accumulateSound;
            _hitSound = hitSound;
        }

        private void HandleAccumulationStarted(IBulletBall bulletBall)
        {
            PlaySound(_accumulateSound);
            bulletBall.OnHit += () => PlaySound(_hitSound);
        }
    }
}