using System;
using UnityEngine;

namespace Game_Asset.Scripts.CheckPoint
{
    public class CheckPoint : MonoBehaviour
    {        
        public bool isActive = false;

        public Sprite AltSprite;

        public event Action<CheckPoint> Activated;

        private SpriteRenderer _spriteRenderer;
        private Sprite _startSprite;


        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _startSprite = _spriteRenderer.sprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("TriggerInitiator") || isActive) return;
            isActive = true;
            _spriteRenderer.sprite = AltSprite;
            OnActivated();
        }

        public void Reset()
        {
            _spriteRenderer.sprite = _startSprite;
            isActive = false;
        }

        private void OnActivated()
        {
            Activated?.Invoke(this);
        }
    }
}