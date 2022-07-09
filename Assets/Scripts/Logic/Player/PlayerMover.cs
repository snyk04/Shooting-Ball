using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Player
{
    public class PlayerMover
    {
        private readonly Rigidbody _rigidbody;

        private readonly Vector3 _moveDirection;
        private readonly float _moveSpeed;
        
        public PlayerMover(IGameCycle gameCycle, Rigidbody rigidbody, Vector3 moveDirection, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveDirection = moveDirection;
            _moveSpeed = moveSpeed;

            gameCycle.OnGameStart += HandleGameStart;
            gameCycle.OnGameEnd += _ => { HandleGameEnd(); };
        }
        
        private void HandleGameStart()
        {
            _rigidbody.AddForce(_moveDirection * _moveSpeed);
        }
        private void HandleGameEnd()
        {
            _rigidbody.AddForce(-_moveDirection * _moveSpeed);
        }
    }
}