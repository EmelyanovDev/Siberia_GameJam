using UnityEngine;

namespace Game_Asset.Scripts.Portal
{
    public class PortalRotation : MonoBehaviour
    {
        private Transform _selfTransform;
        [SerializeField] private float rotationSpeed = 10f;

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
    }
}