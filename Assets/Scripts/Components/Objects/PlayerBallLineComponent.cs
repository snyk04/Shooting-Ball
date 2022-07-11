using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class PlayerBallLineComponent : Component<PlayerBallLine>
    {
        [SerializeField] private Transform _playerBall;
        [SerializeField] private Transform _line;
        
        protected override PlayerBallLine CreateObject()
        {
            return new PlayerBallLine(_playerBall, _line);
        }
    }
}