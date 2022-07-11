using ShootingBall.Objects;
using ShootingBall.Player;
using UnityEngine;

namespace Logic.Audio
{
    public class AccumulativeShooterAudio
    {
        private readonly AudioSource _audioSource;

        private readonly AudioClip _accumulateSound;
        private readonly AudioClip _hitSound;

        public AccumulativeShooterAudio(IAccumulativeShooter accumulativeShooter, AudioSource audioSource,
            AudioClip accumulateSound, AudioClip shotSound, AudioClip hitSound, AudioClip devastationSound)
        {
            _audioSource = audioSource;
            _accumulateSound = accumulateSound;
            _hitSound = hitSound;

            accumulativeShooter.OnAccumulationStarted += HandleAccumulationStarted;
            accumulativeShooter.OnShot += () => PlaySound(shotSound);
            accumulativeShooter.OnDevastation += () => PlaySound(devastationSound);
        }

        private void HandleAccumulationStarted(IBulletBall bulletBall)
        {
            PlaySound(_accumulateSound);
            bulletBall.OnHit += () => PlaySound(_hitSound);
        }
        private void PlaySound(AudioClip sound)
        {
            _audioSource.clip = sound;
            _audioSource.Play();
        }
    }
}