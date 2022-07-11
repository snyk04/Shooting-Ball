using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class ObstacleSpawnerComponent : Component<ObstacleSpawner>
    {
        [Header("Objects")]
        [SerializeField] private GameObject _obstaclePrefab;
        [SerializeField] private Transform _obstacleContainer;

        [Header("Settings")]
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;

        [SerializeField] private float _y;
        
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;
        
        [SerializeField] private int _amountOfObstacles;
        
        protected override ObstacleSpawner CreateObject()
        {
            return new ObstacleSpawner(_obstaclePrefab, _obstacleContainer,
                _minX, _maxX, _y, _minZ, _maxZ, _amountOfObstacles);
        }
    }
}