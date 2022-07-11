using System;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.UI
{
    public class PreStartWindow : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        
        [Header("Objects")]
        [SerializeField] private GameObject _container;

        private void Awake()
        {
            _gameCycle.Object.OnGameStart += HandleGameStart;
        }

        private void HandleGameStart()
        {
            _container.SetActive(false);
        }
    }
}