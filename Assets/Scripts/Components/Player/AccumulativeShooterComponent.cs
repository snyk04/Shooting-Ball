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
        [SerializeField] private float _startPower;
        [SerializeField] private float _powerValueToDevastate;
        [SerializeField] private float _bulletBallStartPower;
        [SerializeField] private float _powerStep;
        [SerializeField] private float _shotSpeed;
        [SerializeField] private Vector3 _bulletBallOffset;
        [SerializeField] private Vector3 _shotDirection;
        
        protected override AccumulativeShooter CreateObject()
        {
            return new AccumulativeShooter(
                _playerBall,
                _bulletBallPrefab,
                _startPower,
                _powerValueToDevastate,
                _bulletBallStartPower,
                _powerStep,
                _shotSpeed,
                _bulletBallOffset,
                _shotDirection
                );
        }
    }
}