using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Objects
{
    public class Obstacle : IObstacle
    {
        private readonly GameObject _gameObject;
        private readonly MeshRenderer _meshRenderer;
        
        private readonly Material _infestedMaterial;
        private readonly float _pauseBetweenInfestationAndDestruction;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public Obstacle(GameObject gameObject, MeshRenderer meshRenderer, Material infestedMaterial, 
            float pauseBetweenInfestationAndDestruction)
        {
            _gameObject = gameObject;
            _meshRenderer = meshRenderer;
            _infestedMaterial = infestedMaterial;
            _pauseBetweenInfestationAndDestruction = pauseBetweenInfestationAndDestruction;
        }

        public async void Infest()
        {
            _meshRenderer.material = _infestedMaterial;
            await Task.Delay((int) (_pauseBetweenInfestationAndDestruction * 1000), _cancellationTokenSource.Token);
            Object.Destroy(_gameObject);
        }
    }
}