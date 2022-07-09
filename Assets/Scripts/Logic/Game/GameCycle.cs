using System;
using ShootingBall.Objects;
using ShootingBall.Player;

namespace ShootingBall.Game
{
    public class GameCycle : IGameCycle
    {
        public event Action OnGameStart;
        public event Action<GameEndType> OnGameEnd;

        public GameCycle(IDoorHandler doorHandler, IAccumulativeShooter accumulativeShooter, 
            IPlayerSmashedInObstacleHandler playerSmashedInObstacleHandler)
        {
            doorHandler.OnPlayerEnteredDoor += HandleVictory;
            
            accumulativeShooter.OnDevastation += HandleGameOver;
            playerSmashedInObstacleHandler.OnPlayerSmashedInObstacle += HandleGameOver;
        }

        public void StartGame()
        {
            OnGameStart?.Invoke();
        }
        
        private void HandleVictory()
        {
            OnGameEnd?.Invoke(GameEndType.Victory);
        }
        private void HandleGameOver()
        {
            OnGameEnd?.Invoke(GameEndType.GameOver);
        }
    }
}