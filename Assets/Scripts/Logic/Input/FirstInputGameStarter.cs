using ShootingBall.Game;
using UnityEngine.InputSystem;

namespace ShootingBall.Input
{
    public class FirstInputGameStarter
    {
        private readonly IGameCycle _gameCycle;

        private readonly InputAction _inputAction;

        public FirstInputGameStarter(IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;
            
            _inputAction = new Controls().Player.StartGame;
            _inputAction.performed += HandleFirstInput;
            _inputAction.Enable();
        }

        private void HandleFirstInput(InputAction.CallbackContext obj)
        {
            _inputAction.Disable();
            _gameCycle.StartGame();
        }
    }
}