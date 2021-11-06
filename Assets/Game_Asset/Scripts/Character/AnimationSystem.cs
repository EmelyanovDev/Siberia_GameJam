using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game_Asset.Scripts.Character
{
    public class AnimationSystem : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PhysicsMovement2D physicsMovement2D;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            if (!animator) throw new NullReferenceException($"{nameof(animator)} is null!");
            if (!physicsMovement2D) throw new NullReferenceException($"{nameof(physicsMovement2D)} is null!");
        }

        private void Update() => animator.SetFloat(Speed, physicsMovement2D.Velocity);
    }
}