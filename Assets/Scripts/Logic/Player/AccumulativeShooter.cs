using System;
using System.Threading;
using System.Threading.Tasks;
using ShootingBall.Objects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootingBall.Player
{
    public class AccumulativeShooter : IAccumulativeShooter, IDisposable
    {
        private const int TargetFrameRate = 60;
        
        private const string BulletBallPrefabLacksRigidbodyMessage = "Bullet ball prefab lacks Rigidbody.";
        private const string BulletBallPrefabLacksBulletBallComponentMessage = "Bullet ball prefab lacks BulletBallComponent.";
        
        private readonly Transform _playerBall;
        private readonly GameObject _bulletBallPrefab;

        private readonly float _powerValueToDevastate;
        private readonly float _bulletBallStartPower;
        private readonly float _powerStep;
        private readonly float _shotSpeed;
        private readonly Vector3 _bulletBallOffset;
        private readonly Vector3 _shotDirection;

        private Rigidbody _bulletBallRigidbody;
        private Vector3 _playerBallVelocity;
        
        private CancellationTokenSource _cancellationTokenSource;

        private float _power;
        private float Power
        {
            get => _power;
            set => _power = Math.Max(0, value);
        }

        public event Action<IBulletBall> OnAccumulationStarted;
        public event Action OnShot;
        public event Action OnDevastation;
        
        public AccumulativeShooter(Transform playerBall, GameObject bulletBallPrefab, float startPower, 
            float powerValueToDevastate, float bulletBallStartPower, float powerStep, float shotSpeed, Vector3 bulletBallOffset,
            Vector3 shotDirection)
        {
            CheckBulletBallPrefab(bulletBallPrefab);
            
            _playerBall = playerBall;
            _bulletBallPrefab = bulletBallPrefab;

            _power = startPower;
            _powerValueToDevastate = powerValueToDevastate;
            _bulletBallStartPower = bulletBallStartPower;
            _powerStep = powerStep;
            _shotSpeed = shotSpeed;
            _bulletBallOffset = bulletBallOffset;
            _shotDirection = shotDirection;

            PreparePlayerBall(playerBall, startPower);
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
        private void PreparePlayerBall(Transform playerBall, float startPower)
        {
            Vector3 oldPlayerBallPosition = playerBall.position;
            playerBall.position = new Vector3(
                oldPlayerBallPosition.x,
                startPower,
                oldPlayerBallPosition.z
            );
            playerBall.localScale = Vector3.one * startPower;
        }
        
        public void StartAccumulating()
        {
            GameObject bulletBall = CreateBulletBall();
            SetBallsPower(_playerBall, bulletBall);
            PushBulletBall(bulletBall);
            OnAccumulationStarted?.Invoke(bulletBall.GetComponent<BulletBallComponent>().Object);
            
            _cancellationTokenSource = new CancellationTokenSource();
            Accumulate(bulletBall, _cancellationTokenSource.Token);
        }
        private GameObject CreateBulletBall()
        {
            Vector3 position = _playerBall.position + _bulletBallOffset;
            return Object.Instantiate(_bulletBallPrefab, position, Quaternion.identity);
        }
        private void SetBallsPower(Transform playerBall, GameObject bulletBallObject)
        {
            IBulletBall bulletBall = bulletBallObject.GetComponent<BulletBallComponent>().Object;
            
            Power -= _bulletBallStartPower;
            bulletBall.IncreasePower(_bulletBallStartPower);
            
            playerBall.localScale = Vector3.one * Power;
            bulletBallObject.transform.localScale = Vector3.one * bulletBall.Power;
        }
        private void PushBulletBall(GameObject bulletBall)
        {
            _bulletBallRigidbody = bulletBall.GetComponent<Rigidbody>();
            _playerBallVelocity = _playerBall.GetComponent<Rigidbody>().velocity;
            _bulletBallRigidbody.velocity = _playerBallVelocity;
        }
        
        private async void Accumulate(GameObject bulletBallObject, CancellationToken cancellationToken)
        {
            IBulletBall bulletBall = bulletBallObject.GetComponent<BulletBallComponent>().Object;
            
            while (!cancellationToken.IsCancellationRequested)
            {
                if (IsPlayerBallDevastated())
                {
                    HandleDevastation();
                    return;
                }

                bulletBall.IncreasePower(_powerStep * 2);
                Power -= _powerStep;
                
                bulletBallObject.transform.localScale = Vector3.one * bulletBall.Power;
                _playerBall.localScale = Vector3.one * Power;
                
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
            return _power <= _powerValueToDevastate;
        }
        private void HandleDevastation()
        {
            _bulletBallRigidbody.isKinematic = true;
            _cancellationTokenSource.Cancel();
            OnDevastation?.Invoke();
        }

        public void Shoot()
        {
            if (_cancellationTokenSource == null || _bulletBallRigidbody == null)
            {
                return;
            }
            
            OnShot?.Invoke();
            _bulletBallRigidbody.AddForce(_shotDirection * _shotSpeed - _playerBallVelocity);
            _cancellationTokenSource.Cancel();
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}