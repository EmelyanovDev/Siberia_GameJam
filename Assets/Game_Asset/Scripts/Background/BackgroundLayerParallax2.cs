using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game_Asset.Scripts.Background
{
    [ExecuteInEditMode]
    public class BackgroundLayerParallax2 : MonoBehaviour
    {
        [SerializeField] private Vector2 slowerBy;
        [SerializeField] private Transform target;

        private Transform _selfTransform;
        
        private float value = 100f;
        
        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            var position = _selfTransform.position;
            position = new Vector3(target.position.x * ((value - slowerBy.x) / value), target.position.y * ((value - slowerBy.y) / value), position.z);
            _selfTransform.position = position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_selfTransform.position, new Vector3(100f, 20f, 0f));
        }
    }
}