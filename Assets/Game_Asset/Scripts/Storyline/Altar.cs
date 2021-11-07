using System;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _starTemplate;
    [SerializeField] private Transform _starEndPoint;
    [SerializeField] private float _starSpeedMove;

    private GameObject star;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
            star = Instantiate(_starTemplate, _playerTransform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (star != null)
        {
            if (star.transform.position != _starEndPoint.position)
            {
                star.transform.position = Vector3.MoveTowards(star.transform.position, _starEndPoint.position,
                    _starSpeedMove * Time.deltaTime);
            }
        }
    }
}
