using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private Conundrum[] controlled;
        private bool _isTrigger = false;
        
        public void OnMouseDown()
        {
            if (!_isTrigger) return;
            foreach (var element in controlled) 
                element.Activate();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
                _isTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
                _isTrigger = false;
        }
    }
}
