using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Player
{
    public class PlayerMoverComponent : Component<PlayerMover>
    {
        [Header("References")] 
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Settings")] 
        [SerializeField] private Vector3 _moveDirection;
        [SerializeField] private float _moveSpeed;
        
        protected override PlayerMover CreateObject()
        {
            return new PlayerMover(_gameCycle.Object, _rigidbody, _moveDirection, _moveSpeed);
        }
    }
}