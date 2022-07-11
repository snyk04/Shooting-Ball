using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class GameCycleVoiceOverComponent : Component<GameCycleVoiceOver>
    {
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
            
        [Header("Objects")]
        [SerializeField] private AudioSource _audioSource;
        
        [Header("Sounds")]
        [SerializeField] private AudioClip _victorySound;

        protected override GameCycleVoiceOver CreateObject()
        {
            return new GameCycleVoiceOver(_gameCycle.Object, _audioSource, _victorySound);
        }
    }
}