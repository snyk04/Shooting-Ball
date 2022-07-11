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
            _camera = camera;
            _objectToAlign = objectToAlign;
            _alignmentOffset = alignmentOffset;
            
            gameCycle.OnGameStart += () => AlignRoutine(_cancellationTokenSource.Token);

            Align();
        }

        private async void AlignRoutine(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Align();
                await Task.Yield();
            }
        }
        private void Align()
        {
            _camera.position = _objectToAlign.position + _alignmentOffset;
        }
        
        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}