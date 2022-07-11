using ShootingBall.Game;
using ShootingBall.Player;
using UnityEngine.InputSystem;

namespace ShootingBall.Input
{
    public class PlayerInput : IPlayerInput
    {
        private readonly IAccumulativeShooter _accumulativeShooter;
        private readonly InputAction _inputAction;
        
        public PlayerInput(IAccumulativeShooter accumulativeShooter, IGameCycle gameCycle)
        {
            _accumulativeShooter = accumulativeShooter;
            
            _inputAction = new Controls().Player.StartAccumulating;
            _inputAction.started += HandleAccumulationStart;
            _inputAction.performed += HandleAccumulationStop;
            
            gameCycle.OnGameEnd += _ => HandleGameEnd();

            Enable();
        }

        public void Enable()
        {
            _inputAction.Enable();
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