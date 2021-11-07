using System;
using System.Collections;
using Game_Asset.Scripts.Character;
using Game_Asset.Scripts.GameManager;
using Game_Asset.Scripts.PostEffects;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Apple : MonoBehaviour
{
    [SerializeField] private float _jumpOffDelay;
    [SerializeField] private float _jumpFromPlayerForce;
    [SerializeField] private VignetteFilter _vignetteFilter;
    [SerializeField] private GameObject _neutronStar;
    
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
            GameMaster.Instance.AllowedControl();
            
            _vignetteFilter.useFilter = true;
            StartCoroutine(Timer(0.1f, 0f, 10f, f =>
            {
                _vignetteFilter.exp = f;
            }));

            StartCoroutine(Timer2(0.1f, () =>
            {
                StartCoroutine(Timer(0.1f, 10f, 0f, f =>
                {
                    _vignetteFilter.exp = f;
                }));
            }));
            StartCoroutine(Timer2(0.2f, () =>
            {
                _vignetteFilter.useFilter = false;
                _neutronStar.SetActive(true);
            }));
        }
    }
    
    IEnumerator Timer2(float duration, Action target)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            yield return null;
        }
        target();
    }
    IEnumerator Timer(float duration, float begin, float end, Action<float> target)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            target(Mathf.Lerp(begin, end, t / duration));
            yield return null;
        }
        target(end);
    }
    
}
