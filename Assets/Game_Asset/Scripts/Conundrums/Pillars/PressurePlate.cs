using System;
using Game_Asset.Scripts.Character;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums.Pillars
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private Conundrum[] _controlled;
        [SerializeField] private float _bottomPositionOffset;
        [SerializeField] private float _pressingSpeed;
        [SerializeField] private float _pressDelay;

        private BoxCollider2D _trigger;

        private Vector3 _targetPosition;

        private Vector3 _topPosition;
        private Vector3 _bottomPosition;

        private void Start()
        {
            _trigger = GetComponent<BoxCollider2D>();

            _topPosition = transform.position;
            _bottomPosition = _topPosition + Vector3.up * _bottomPositionOffset;
            _targetPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
            {
                _trigger.enabled = false;
                foreach (var conondrum in _controlled)
                {
                    conondrum.Activate();
                }
                _targetPosition = _bottomPosition;
                Invoke(nameof(SetTopTargetPosition), _pressDelay);
            }
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _pressingSpeed * Time.deltaTime);
        }

        private void SetTopTargetPosition()
        {
            _targetPosition = _topPosition;
            _trigger.enabled = true;
        }
    }
}
