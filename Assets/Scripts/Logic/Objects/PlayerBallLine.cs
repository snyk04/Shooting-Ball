using System;
using System.Threading;
using System.Threading.Tasks;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class PlayerBallLine : IDisposable
    {
        private readonly Transform _playerBall;
        private readonly Transform _line;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public PlayerBallLine(Transform playerBall, Transform line)
        {
            _playerBall = playerBall;
            _line = line;
            
            FollowBall(_cancellationTokenSource.Token);
        }
        private async void FollowBall(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Vector3 oldScale = _line.localScale;
                _line.localScale = new Vector3(
                    _playerBall.localScale.x,
                    oldScale.y,
                    oldScale.z
                );
                
                await Task.Yield();
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}