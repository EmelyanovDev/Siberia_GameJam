using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WaterSimulator : MonoBehaviour
{
    [SerializeField] private Transform waterLevel;
    [SerializeField] private float waterDensity = 10f;
    private Rigidbody2D _rigidbody2D;
    private Transform _selfTransform;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _selfTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        var divePercent = -_selfTransform.position.y + waterLevel.position.y + _selfTransform.localScale.x * 0.5f;
        divePercent = Mathf.Clamp(divePercent, 0f, 1f);
        _rigidbody2D.AddForce(Vector2.up * (divePercent * waterDensity));
        _rigidbody2D.drag = divePercent * 2f;
        _rigidbody2D.angularDrag = divePercent * 2f;
    }
}
