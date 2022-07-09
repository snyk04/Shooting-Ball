using System;
using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class ObstacleComponent : Component<Obstacle>
    {
        [Header("Objects")]
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _infestedMaterial;
        
        [Header("Settings")]
        [SerializeField] private float _pauseBetweenInfestationAndDestruction;
        
        protected override Obstacle CreateObject()
        {
            return new Obstacle(gameObject, _meshRenderer, _infestedMaterial, _pauseBetweenInfestationAndDestruction);
        }
    }
}