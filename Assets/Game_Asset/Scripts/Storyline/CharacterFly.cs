using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Game_Asset.Scripts.Storyline
{
    public class CharacterFly : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Rigidbody2D _playerTransform;
        [SerializeField] private float _moveSpeed;
        public bool _fly;

        public void SetBodyKinematic()
        {
            _playerTransform.bodyType = RigidbodyType2D.Kinematic;
        }

        private void Update()
        {
            if (_fly)
            {
                _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _endPoint.position,
                    _moveSpeed * Time.deltaTime);
            }
                
                
        }
    }
}
