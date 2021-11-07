using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    [RequireComponent(typeof(Animator))]
    public class Lever : MonoBehaviour
    {
        [SerializeField] private Conundrum[] controlled;
        [SerializeField] private Trigger _trigger;
        
        [SerializeField] private Animator _leverAnimator;
        [SerializeField] private bool _active = false;
        [SerializeField] private AudioSource _clickSound;
        
        private static readonly int PlayActivation = Animator.StringToHash("PlayActivation");

        public void Reset()
        {
            _active = false;
        }

        private void OnMouseDown()
        {
            if (!_trigger.IsTrigger || _active) return;
            _leverAnimator.SetTrigger(PlayActivation);
            _clickSound.Play();
            foreach (var element in controlled) element.Activate();
            _active = true;
        }
    }
}