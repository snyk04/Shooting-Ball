using ShootingBall.Game;
using UnityEngine.InputSystem;

namespace ShootingBall.Input
{
    public class FirstInputGameStarter
    {
        private readonly IGameCycle _gameCycle;
        private readonly IPlayerInput _playerInput;

        private readonly InputAction _inputAction;

        public FirstInputGameStarter(IGameCycle gameCycle, IPlayerInput playerInput)
        {
            _gameCycle = gameCycle;
            _playerInput = playerInput;
            
            _inputAction = new Controls().Player.StartGame;
            _inputAction.performed += HandleFirstInput;
            _inputAction.Enable();
        }

        private void HandleFirstInput(InputAction.CallbackContext obj)
        {
            _playerInput.Enable();
            _inputAction.Disable();
            
            _gameCycle.StartGame();
        }
    }
}