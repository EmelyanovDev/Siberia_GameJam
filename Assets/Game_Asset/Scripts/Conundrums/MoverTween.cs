using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums.Walls
{
    public class MoverTween : Conundrum
    {
        [SerializeField] private float _topOffset;
        [SerializeField] private float _moveSpeed;

        private Vector3 _bottomPosition;
        private Vector3 _topPosition;
        
        private Vector3 _targetPosition;
        

        private void Start()
        {
            _targetPosition = transform.position;
            
            _bottomPosition = transform.position;
            _topPosition = _bottomPosition + Vector3.up * _topOffset;
        }

        public void SetTargetPosition()
        {
            if (_targetPosition == _topPosition)
                _targetPosition = _bottomPosition;
            else
                _targetPosition = _topPosition;
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }

        public override void Activate()
        {
            SetTargetPosition();
        }
    }
}
