using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSounder : MonoBehaviour
{
    [SerializeField] private AudioSource _portalSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("A");
        if(other.gameObject.layer == LayerMask.NameToLayer("Character"))
            _portalSound.Play();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Character"))
            _portalSound.Stop();
    }
}
