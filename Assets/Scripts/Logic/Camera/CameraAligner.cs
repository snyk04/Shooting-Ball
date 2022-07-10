using System;
using System.Threading;
using System.Threading.Tasks;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Camera
{
    public class CameraAligner : IDisposable
    {
        private readonly Transform _camera;
        private readonly Transform _objectToAlign;
        private readonly Vector3 _alignmentOffset;

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        
        public CameraAligner(IGameCycle gameCycle, Transform camera, Transform objectToAlign, Vector3 alignmentOffset)
        {
            gameCycle.OnGameStart += () => Align(_cancellationTokenSource.Token);

            _camera = camera;
            _objectToAlign = objectToAlign;
            _alignmentOffset = alignmentOffset;
        }

        private async void Align(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _camera.position = _objectToAlign.position + _alignmentOffset;
                await Task.Yield();
            }
        }


        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}