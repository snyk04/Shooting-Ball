using ShootingBall.Common;
using ShootingBall.Game;
using UnityEngine;

namespace ShootingBall.Camera
{
    public class CameraAlignerComponent : Component<CameraAligner>
    {
        [Header("References")]
        [SerializeField] private GameCycleComponent _gameCycle;
        
        [Header("Objects")]
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _objectToAlign;
        
        [Header("Settings")]
        [SerializeField] private Vector3 _alignmentOffset;
        
        protected override CameraAligner CreateObject()
        {
            return new CameraAligner(_gameCycle.Object, _camera, _objectToAlign, _alignmentOffset);
        }
    }
}