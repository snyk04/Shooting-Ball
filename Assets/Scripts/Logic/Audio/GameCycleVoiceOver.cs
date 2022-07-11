﻿using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class GameCycleVoiceOver : VoiceOver
    {
        private readonly AudioClip _victorySound;
        
        public GameCycleVoiceOver(IGameCycle gameCycle, AudioSource audioSource, 
            AudioClip victorySound) : base(audioSource)
        {
            _victorySound = victorySound;

            gameCycle.OnGameEnd += HandleGameEnd;
        }

        private void HandleGameEnd(GameEndType gameEndType)
        {
            if (gameEndType == GameEndType.Victory)
            {
                PlaySound(_victorySound);
            }
        }
    }
}