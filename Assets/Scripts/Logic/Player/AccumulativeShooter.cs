﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ShootingBall.Objects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Player
{
    public class AccumulativeShooter : IAccumulativeShooter
    {
        private const int TargetFrameRate = 60;
        private const float DevastateScaleValue = 0.1f;

        private const string BulletBallPrefabLacksRigidbodyMessage = "Bullet ball prefab lacks Rigidbody.";
        private const string BulletBallPrefabLacksBulletBallComponentMessage = "Bullet ball prefab lacks BulletBallComponent.";
        private const string NoAccumulationErrorMessage = "You can't shoot without accumulation.";
        
        private readonly Transform _playerBall;
        private readonly GameObject _bulletBallPrefab;
        
        private readonly float _scaleStep;
        private readonly float _shotPower;
        private readonly Vector3 _bulletBallOffset;
        private readonly Vector3 _shotDirection;

        private Rigidbody _bulletBallRigidbody;
        private CancellationTokenSource _cancellationTokenSource;
        
        public event Action OnDevastation;
        
        public AccumulativeShooter(Transform playerBall, GameObject bulletBallPrefab, 
            float scaleStep, float shotPower, Vector3 bulletBallOffset, Vector3 shotDirection)
        {
            CheckBulletBallPrefab(bulletBallPrefab);
            
            _playerBall = playerBall;
            _bulletBallPrefab = bulletBallPrefab;

            _scaleStep = scaleStep;
            _shotPower = shotPower;
            _bulletBallOffset = bulletBallOffset;
            _shotDirection = shotDirection;
        }
        private void CheckBulletBallPrefab(GameObject bulletBallPrefab)
        {
            if (!bulletBallPrefab.TryGetComponent(out Rigidbody _))
            {
                throw new ArgumentException(BulletBallPrefabLacksRigidbodyMessage);
            }

            if (!bulletBallPrefab.TryGetComponent(out BulletBallComponent _))
            {
                throw new ArgumentException(BulletBallPrefabLacksBulletBallComponentMessage);
            }
        }
        
        public void StartAccumulating()
        {
            GameObject bulletBallObject = CreateBulletBall();
            _bulletBallRigidbody = bulletBallObject.GetComponent<Rigidbody>();
            
            _cancellationTokenSource = new CancellationTokenSource();
            Accumulate(bulletBallObject, _cancellationTokenSource.Token);
        }
        private GameObject CreateBulletBall()
        {
            GameObject bulletBall = Object.Instantiate(_bulletBallPrefab, _playerBall.position + _bulletBallOffset, Quaternion.identity);
            bulletBall.transform.localScale = Vector3.zero;
            
            return bulletBall;
        }
        private async void Accumulate(GameObject bulletBallObject, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (IsPlayerBallDevastated())
                {
                    HandleDevastation();
                    return;
                }

                bulletBallObject.transform.localScale += Vector3.one * _scaleStep;
                _playerBall.localScale -= Vector3.one * _scaleStep;

                try
                {
                    await Task.Delay((int)(1f / TargetFrameRate * 1000), cancellationToken);
                }
                catch
                {
                    return;
                }
            }
        }
        private bool IsPlayerBallDevastated()
        {
            return _playerBall.localScale.x <= DevastateScaleValue;
        }
        private void HandleDevastation()
        {
            _cancellationTokenSource.Cancel();
            OnDevastation?.Invoke();
        }

        public void Shoot()
        {
            if (_cancellationTokenSource == null || _bulletBallRigidbody == null)
            {
                Debug.LogError(NoAccumulationErrorMessage);
                return;
            }
            
            _bulletBallRigidbody.AddForce(_shotDirection * _shotPower);
            _cancellationTokenSource.Cancel();
        }
    }
}