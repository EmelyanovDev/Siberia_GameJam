using UnityEngine;
using UnityEngine.Serialization;

public class CameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(720, 1280);
    [FormerlySerializedAs("WidthOrHeight")] [Range(0f, 1f)] public float widthOrHeight = 0;

    private Camera _componentCamera;
    
    private float _initialSize;
    private float _targetAspect;

    private float _initialFov;
    private float _horizontalFov = 120f;

    private void Start()
    {
        _componentCamera = GetComponent<Camera>();
        _initialSize = _componentCamera.orthographicSize;

        _targetAspect = DefaultResolution.x / DefaultResolution.y;

        _initialFov = _componentCamera.fieldOfView;
        _horizontalFov = CalcVerticalFov(_initialFov, 1 / _targetAspect);
        
        if (_componentCamera.orthographic)
        {
            float constantWidthSize = _initialSize * (_targetAspect / _componentCamera.aspect);
            _componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, widthOrHeight);
        }
        else
        {
            float constantWidthFov = CalcVerticalFov(_horizontalFov, _componentCamera.aspect);
            _componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, _initialFov, widthOrHeight);
        }
    }

    private void Update()
    {
        
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

        return vFovInRads * Mathf.Rad2Deg;
    }
}