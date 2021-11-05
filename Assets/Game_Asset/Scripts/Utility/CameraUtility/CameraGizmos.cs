using UnityEngine;

namespace Game_Asset.Scripts.Utility.CameraUtility
{
    [ExecuteInEditMode]
    public class CameraGizmos : MonoBehaviour
    {
        private Camera _camera;
        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnDrawGizmos()
        {
            float width = _camera.pixelWidth;
            float height = _camera.pixelHeight;
            Vector3 a = _camera.ScreenToWorldPoint(new Vector2 (0, 0));
            Vector3 b = _camera.ScreenToWorldPoint(new Vector2 (width, height));
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position + Vector3.forward * 50f, new Vector3(b.x - a.x, b.y - a.y, 100));
            Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1f));
            
        }
    }
}