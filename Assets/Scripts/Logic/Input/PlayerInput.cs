using ShootingBall.Game;
using ShootingBall.Player;
using UnityEngine.InputSystem;

namespace ShootingBall.Input
{
    public class PlayerInput
    {
        private readonly IAccumulativeShooter _accumulativeShooter;
        private readonly InputAction _inputAction;
        
        public PlayerInput(IAccumulativeShooter accumulativeShooter, IGameCycle gameCycle)
        {
            _accumulativeShooter = accumulativeShooter;
            
            var controls = new Controls();
            _inputAction = controls.Player.StartAccumulating;
            _inputAction.started += HandleAccumulationStart;
            _inputAction.performed += HandleAccumulationStop;
            
            _inputAction.Enable();

            gameCycle.OnGameEnd += _ => HandleGameEnd();
        }
        
        private void HandleAccumulationStart(InputAction.CallbackContext obj)
        {
            _accumulativeShooter.StartAccumulating();
        }
        private void HandleAccumulationStop(InputAction.CallbackContext obj)
        {
            _accumulativeShooter.Shoot();
        }
        
        private void HandleGameEnd()
        {
            _inputAction.Disable();
        }
    }
}