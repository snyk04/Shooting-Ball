using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class BackgroundMusicVoiceOver : VoiceOver
    {
        public BackgroundMusicVoiceOver(AudioSource audioSource, IGameCycle gameCycle, AudioClip backgroundMusic) :
            base(audioSource)
        {
            PlaySound(backgroundMusic);

            gameCycle.OnGameEnd += _ => audioSource.Stop();
        }
    }
}