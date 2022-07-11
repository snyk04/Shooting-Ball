﻿using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace Logic.Audio
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
            return new PlayerSmashInObstacleVoiceOver(_playerSmashedInObstacleHandler.Object, _audioSource, _smashSound);
        }
    }
}