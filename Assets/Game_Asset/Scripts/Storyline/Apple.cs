using Game_Asset.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Apple : MonoBehaviour
{
    [SerializeField] private float _jumpOffDelay;
    [SerializeField] private float _jumpFromPlayerForce;

    [SerializeField] private KeyboardInput _playerKeyboardInput;
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _circleCollider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        
        Invoke(nameof(JumpOff), _jumpOffDelay);
    }

    private void JumpOff()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            _rigidbody.AddForce(Vector3.right * _jumpFromPlayerForce);
            _rigidbody.AddForce(Vector3.up * _jumpFromPlayerForce);

            _circleCollider.enabled = false;
            _playerKeyboardInput.enabled = true;
        }
            
    }
}
