using System;
using Game_Asset.Scripts.Conundrums;
using UnityEngine;

public class Closer : MonoBehaviour
{
    [SerializeField] private Conundrum[] _walls;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            foreach (var wall in _walls)
            {
                wall.Activate();
            }
        }
    }
}
