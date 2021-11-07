using UnityEngine;

namespace Game_Asset.Scripts.Storyline
{
    public class StarRotation : MonoBehaviour
    {
        private Transform _selfTransform;
        private float rotationSpeed = 0f;

        private float _speed = 0f;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            _speed += rotationSpeed * Time.deltaTime;
            var r = _selfTransform.rotation.eulerAngles;
            _selfTransform.rotation = Quaternion.AngleAxis(_speed, Vector3.forward);
        }

        public void SetRotationSpeed(float speed)
        {
            rotationSpeed = speed;
        }
    }
}