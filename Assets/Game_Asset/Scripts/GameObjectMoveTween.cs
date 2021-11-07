using UnityEngine;

namespace Game_Asset.Scripts
{
    public class GameObjectMoveTween : MonoBehaviour
    {
        [SerializeField] private AnimationCurve animationCurve;
        public Transform target;
        public float duration = 0.2f;
        public Vector3 endPoint;
        public Vector3 beginPoint;
        
        private float _t = 0f;
        private void Awake()
        {
            target.position = beginPoint;
        }

        private void Update()
        {
            if (_t < duration)
            {
                _t += Time.deltaTime;
                target.position = Vector3.Lerp(beginPoint, endPoint, animationCurve.Evaluate(_t / duration));
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