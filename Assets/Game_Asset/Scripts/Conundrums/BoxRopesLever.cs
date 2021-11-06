using System;
using System.Collections;
using Game_Asset.Scripts.Conundrums;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoxRopesLever : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;

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
        if (!_trigger.IsTrigger) return;
        _leverAnimator.SetTrigger("PlayActivation");
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
