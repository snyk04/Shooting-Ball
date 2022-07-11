using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class PlayerSmashInObstacleVoiceOver : VoiceOver
    {
        public PlayerSmashInObstacleVoiceOver(IPlayerSmashedInObstacleHandler playerSmashedInObstacleHandler, 
            AudioSource audioSource, AudioClip smashSound) : base(audioSource)
        {
            playerSmashedInObstacleHandler.OnPlayerSmashedInObstacle += () => PlaySound(smashSound);
        }
    }
}