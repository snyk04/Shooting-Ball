using ShootingBall.Player;
using UnityEngine.InputSystem;

namespace ShootingBall.Input
{
    public class PlayerInput
    {
        private readonly IAccumulativeShooter _accumulativeShooter;

        public PlayerInput(IAccumulativeShooter accumulativeShooter)
        {
            _accumulativeShooter = accumulativeShooter;
            
            var controls = new Controls();
            InputAction inputAction = controls.Player.StartAccumulating;
            inputAction.Enable();
            
            inputAction.started += HandleAccumulationStart;
            inputAction.performed += HandleAccumulationStop;
        }
        
        private void HandleAccumulationStart(InputAction.CallbackContext obj)
        {
            _accumulativeShooter.StartAccumulating();
        }
        private void HandleAccumulationStop(InputAction.CallbackContext obj)
        {
            _accumulativeShooter.Shoot();
        }
    }
}