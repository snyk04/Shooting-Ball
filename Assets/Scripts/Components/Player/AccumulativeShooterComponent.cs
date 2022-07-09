using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Player
{
    public class AccumulativeShooterComponent : Component<AccumulativeShooter>
    {
        [Header("Objects")]
        [SerializeField] private Transform _playerBall;
        [SerializeField] private GameObject _bulletBallPrefab;
        
        [Header("Settings")]
        [SerializeField] private float _scaleStep;
        [SerializeField] private float _shotPower;
        [SerializeField] private Vector3 _bulletBallOffset;
        [SerializeField] private Vector3 _shotDirection;
        
        protected override AccumulativeShooter CreateObject()
        {
            return new AccumulativeShooter(
                _playerBall,
                _bulletBallPrefab,
                _scaleStep,
                _shotPower,
                _bulletBallOffset,
                _shotDirection
                );
        }
    }
}