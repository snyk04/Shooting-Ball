using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Input
{
    public class FirstInputGameStarterComponent : Component<FirstInputGameStarter>
    {
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private PlayerInputComponent _playerInput;
        
        protected override FirstInputGameStarter CreateObject()
        {
            return new FirstInputGameStarter(_gameCycle.Object, _playerInput.Object);
        }
    }
}