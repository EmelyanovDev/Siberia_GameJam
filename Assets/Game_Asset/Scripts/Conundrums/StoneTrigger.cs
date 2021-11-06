using System;
using UnityEngine;

public class StoneTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _stoneRigidBody;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Character"))
            _stoneRigidBody.bodyType = RigidbodyType2D.Dynamic;
    }
}