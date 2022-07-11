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

        public PlayerBallLine(IGameCycle gameCycle, Transform playerBall, Transform line)
        {
            _playerBall = playerBall;
            _line = line;

            gameCycle.OnGameStart += () => CopyBallWidthRoutine(_cancellationTokenSource.Token);

            CopyBallWidth();
        }
        private async void CopyBallWidthRoutine(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                CopyBallWidth();
                await Task.Yield();
            }
        }
        private void CopyBallWidth()
        {
            Vector3 oldScale = _line.localScale;
            _line.localScale = new Vector3(_playerBall.localScale.x, oldScale.y, oldScale.z);
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}