using System;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _starTemplate;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var star = Instantiate(_starTemplate, _playerTransform);
    }
}
