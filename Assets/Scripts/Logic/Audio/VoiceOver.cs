using UnityEngine;

namespace ShootingBall.Audio
{
    public abstract class VoiceOver
    {
        private readonly AudioSource _audioSource;

        protected VoiceOver(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
        
        protected void PlaySound(AudioClip sound)
        {
            _audioSource.clip = sound;
            _audioSource.Play();
        }
    }
}