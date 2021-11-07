using System;
using System.Collections;
using System.Collections.Generic;
using Game_Asset.Scripts.Character;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _walkSound;
    [SerializeField] private Rigidbody2D _rigidbody;
    private PhysicsMovement2D _physicsMovement2D;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (Mathf.Abs(_rigidbody.velocity.x) > 1)
            {
                if(!_walkSound.isPlaying)
                    _walkSound.Play();
            }
            else
            {
                _walkSound.Stop();
            }
        }
            
    }
}
