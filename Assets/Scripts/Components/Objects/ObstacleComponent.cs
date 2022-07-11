using System;
using ShootingBall.Common;
using UnityEngine;

namespace ShootingBall.Objects
{
    public class ObstacleComponent : Component<Obstacle>
    {
        [Header("Objects")]
        [SerializeField] private MeshRenderer _meshRenderer;
        
        [Header("Settings")]
        [SerializeField] private Material _infestedMaterial;
        [SerializeField] private float _pauseBetweenInfestationAndDestruction;
        
        protected override Obstacle CreateObject()
        {
            return new Obstacle(gameObject, _meshRenderer, _infestedMaterial, _pauseBetweenInfestationAndDestruction);
        }
    }
}