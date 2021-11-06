using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float _jumpOffDelay;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        Invoke(nameof(JumpOff), _jumpOffDelay);
    }

    private void JumpOff()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}
