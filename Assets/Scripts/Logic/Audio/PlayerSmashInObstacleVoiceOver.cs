using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class PlayerSmashInObstacleVoiceOver : VoiceOver
    {
        public PlayerSmashInObstacleVoiceOver(AudioSource audioSource,
            IPlayerSmashedInObstacleHandler playerSmashedInObstacleHandler, AudioClip smashSound) : base(audioSource)
        {
            playerSmashedInObstacleHandler.OnPlayerSmashedInObstacle += () => PlaySound(smashSound);
        }
    }
}