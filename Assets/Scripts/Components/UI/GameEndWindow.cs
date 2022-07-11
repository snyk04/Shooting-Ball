using System;
using System.Collections.Generic;
using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingBall.UI
{
    public class GameEndWindow : MonoBehaviour
    {
        private const string WrongGameEndTypeMessage = "Wrong game end type";
        
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        [SerializeField] private SceneLoaderComponent _sceneLoader;

        [Header("Objects")]
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _okButton;
        [SerializeField] private Text _gameResultText;
        
        [Header("Settings")]
        [SerializeField] private string _victoryText;
        [SerializeField] private string _gameOverText;

        private Dictionary<GameEndType, string> _gameEndTypeToGameResultTextDictionary;

        private void Awake()
        {
            IGameCycle gameCycle = _gameCycle.Object;
            ISceneLoader sceneLoader = _sceneLoader.Object;
            
            gameCycle.OnGameEnd += HandleGameEnd;
            _okButton.onClick.AddListener(sceneLoader.ReloadCurrentScene);
            
            _gameEndTypeToGameResultTextDictionary = new Dictionary<GameEndType, string>
            {
                [GameEndType.Victory] = _victoryText,
                [GameEndType.GameOver] = _gameOverText
            };
        }

        private void HandleGameEnd(GameEndType gameEndType)
        {
            if (!_gameEndTypeToGameResultTextDictionary.ContainsKey(gameEndType))
            {
                throw new ArgumentException(WrongGameEndTypeMessage);
            }

            _container.SetActive(true);
            _gameResultText.text = _gameEndTypeToGameResultTextDictionary[gameEndType];
        }
    }
}