using ShootingBall.Common;
using ShootingBall.Player;
using UnityEngine;

namespace ShootingBall.Audio
{
    public class AccumulativeShooterVoiceOverComponent : Component<AccumulativeShooterVoiceOver>
    {
        [Header("References")]
        [SerializeField] private AccumulativeShooterComponent _accumulativeShooter;
        
        [Header("Objects")]
        [SerializeField] private AudioSource _audioSource;
        
        [Header("Sounds")]
        [SerializeField] private AudioClip _accumulateSound;
        [SerializeField] private AudioClip _shotSound;
        [SerializeField] private AudioClip _hitSound;
        [SerializeField] private AudioClip _devastationSound;   
        
        protected override AccumulativeShooterVoiceOver CreateObject()
        {
            return new AccumulativeShooterVoiceOver(_accumulativeShooter.Object, _audioSource, _accumulateSound, _shotSound,
                _hitSound, _devastationSound);
        }
    }
}