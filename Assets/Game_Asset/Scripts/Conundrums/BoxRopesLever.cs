using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoxRopesLever : MonoBehaviour
{
    private bool _isTrigger;

    private Animator _leverAnimator;

    private Vector3 _targetPosition;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _targetMoveSpeed;
    [SerializeField] private Vector3 _bottomPosition;

    private void Start()
    {
        _leverAnimator = GetComponent<Animator>();
        _targetPosition = _targetTransform.position;
    }

    public void OnMouseDown()
    {
        if (!_isTrigger) return;
        _leverAnimator.SetTrigger("PlayActivation");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
            _isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
            _isTrigger = false;
    }

    private void Update()
    {
        if (_targetTransform.position.y >= _targetPosition.y)
        {
            _targetTransform.position = Vector3.MoveTowards(_targetTransform.position, _targetPosition,
                _targetMoveSpeed * Time.deltaTime);
        }
    }

    public void SetTargetPosition()
    {
        _targetPosition += _bottomPosition;
    }
}
