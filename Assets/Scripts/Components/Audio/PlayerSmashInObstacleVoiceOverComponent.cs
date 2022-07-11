using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class PlayerSmashInObstacleVoiceOverComponent : Component<PlayerSmashInObstacleVoiceOver>
    {
        [Header("References")] 
        [SerializeField] private PlayerSmashedInObstacleHandlerComponent _playerSmashedInObstacleHandler;

        [Header("Objects")] 
        [SerializeField] private AudioSource _audioSource;

        [Header("Sounds")] 
        [SerializeField] private AudioClip _smashSound;
        
        protected override PlayerSmashInObstacleVoiceOver CreateObject()
        {
            return new PlayerSmashInObstacleVoiceOver(_audioSource, _playerSmashedInObstacleHandler.Object, _smashSound);
        }
    }
}