using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class PlayerBallLineComponent : Component<PlayerBallLine>
    {
        [Header("References")] 
        [SerializeField] private GameCycleComponent _gameCycle;
        
        [Header("Objects")]
        [SerializeField] private Transform _playerBall;
        [SerializeField] private Transform _line;
        
        protected override PlayerBallLine CreateObject()
        {
            return new PlayerBallLine(_gameCycle.Object, _playerBall, _line);
        }
    }
}