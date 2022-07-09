﻿using ShootingBall.Common;
using ShootingBall.Objects;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Game
{
    public class GameCycleComponent : Component<GameCycle>
    {
        [SerializeField] private DoorHandlerComponent _doorHandler;
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        [SerializeField] private PlayerSmashedInObstacleHandlerComponent _playerSmashedInObstacleHandler;
        
        protected override GameCycle CreateObject()
        {
            return new GameCycle(_doorHandler.Object, _accumulativeShooter.Object,
                _playerSmashedInObstacleHandler.Object);
        }

        private void Start()
        {
            Object.StartGame();
        }
    }
}