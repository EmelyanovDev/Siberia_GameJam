using System;
using System.Collections;
using UnityEngine;

namespace Game_Asset.Scripts
{
    public class HintAnimation : MonoBehaviour
    {
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField] private float duration = 0.2f;
        [SerializeField] private float height = 0.2f;

        private Vector3 endPoint;
        private Vector3 beginPoint;
        private Transform _selfTransform;
        private float _t = 0f;
        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
            beginPoint = _selfTransform.position;
            endPoint = _selfTransform.position + Vector3.up * height;
        }

        private void Update()
        {
            if (_t < duration)
            {
                _t += Time.deltaTime;
                _selfTransform.position = Vector3.Lerp(beginPoint, endPoint, animationCurve.Evaluate(_t / duration));
            }
            else
            {
                _t = 0;
                var b = beginPoint;
                beginPoint = endPoint;
                endPoint = b;
            }
        }
    }
}
