using System;
using System.Threading;
using System.Threading.Tasks;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Player
{
    public class PlayerMover : IDisposable
    {
        private readonly Rigidbody _rigidbody;

        private readonly Vector3 _moveDirection;
        private readonly float _moveSpeed;

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        
        public PlayerMover(IGameCycle gameCycle, Rigidbody rigidbody, Vector3 moveDirection, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveDirection = moveDirection;
            _moveSpeed = moveSpeed;

            gameCycle.OnGameStart += () => MovePlayer(_cancellationTokenSource.Token);
            gameCycle.OnGameEnd += _ => { HandleGameEnd(); };
        }
        
        private async void MovePlayer(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _rigidbody.velocity = _moveDirection * _moveSpeed;
                await Task.Yield();
            }
        }
        private void HandleGameEnd()
        {
            _rigidbody.velocity = Vector3.zero;
            _cancellationTokenSource?.Cancel();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}