using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class BoxRopesLever : Conundrum
    {
        private Vector3 _targetPosition;
        [SerializeField] private Transform targetTransform;
        [SerializeField] private float targetMoveSpeed;
        [SerializeField] private Vector3 bottomPosition;

        private Vector3 _startPosition;
        private void Start()
        {
            _startPosition = targetTransform.position;
            _targetPosition = targetTransform.position;
        }
        private void Update()
        {
            if (targetTransform.position.y >= _targetPosition.y)
            {
                targetTransform.position = Vector3.MoveTowards(targetTransform.position, _targetPosition,
                    targetMoveSpeed * Time.deltaTime);
            }
        }

        public void SetTargetPosition()
        {
            _targetPosition += bottomPosition;
        }

        public override void Activate()
        {
            SetTargetPosition();
        }

        public override void Reset()
        {
            targetTransform.position = _startPosition;
            Start();
        }
    }
}
