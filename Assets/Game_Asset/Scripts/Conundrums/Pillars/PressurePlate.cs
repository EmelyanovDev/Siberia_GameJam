using System;
using Game_Asset.Scripts.Character;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums.Pillars
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private float _bottomOffest;
        [SerializeField] private float _pressingSpeed;

        private Vector2 _bottomPosition;
        private Vector2 _topPosition;

        private Vector2 _targetPosition;
        
        private void Start()
        {
            _topPosition = transform.position;
            _bottomPosition = (Vector2) transform.position - Vector2.down * _bottomOffest;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
                SetTargetPosition();
        }

        private void SetTargetPosition()
        {
            if (_targetPosition == _topPosition) _targetPosition = _bottomPosition;
            else _targetPosition = _topPosition;

        }

        private void Update()
        {
            if ((Vector2) transform.position != _targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _pressingSpeed * Time.deltaTime);
        }
    }
}
