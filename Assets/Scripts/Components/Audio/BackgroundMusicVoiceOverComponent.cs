using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class BackgroundMusicVoiceOverComponent : Component<BackgroundMusicVoiceOver>
    {
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        
        [Header("Objects")]
        [SerializeField] private AudioSource _audioSource;

        [Header("Sounds")] 
        [SerializeField] private AudioClip _backgroundMusic;

        protected override BackgroundMusicVoiceOver CreateObject()
        {
            return new BackgroundMusicVoiceOver(_audioSource, _gameCycle.Object, _backgroundMusic);
        }
    }
}