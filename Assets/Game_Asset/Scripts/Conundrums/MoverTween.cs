using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class MoverTween : Conundrum
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _bottomPositionOffset;

        private Vector3 _targetPosition;

        private Vector3 _bottomPosition;
        private Vector3 _topPosition;

        private Vector3 _startPosition;

        private void Awake() => _startPosition = transform.position;

        private void Start()
        {
            _targetPosition = transform.position;

            _topPosition = _targetPosition;
            _bottomPosition = transform.position + Vector3.up * _bottomPositionOffset;
        }

        public override void Activate()
        {
            SetTargetPosition();
        }

        public override void Reset()
        {
            transform.position = _startPosition;
            Start();
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition,
                    _moveSpeed * Time.deltaTime);
        }

        private void SetTargetPosition()
        {
            if (_targetPosition == _bottomPosition)
                _targetPosition = _topPosition;
            else
                _targetPosition = _bottomPosition;
        }
    }
}
