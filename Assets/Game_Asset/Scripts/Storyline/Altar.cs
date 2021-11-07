using System;
using Game_Asset.Scripts.Storyline;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] private Transform _starCreatePoint;
    [SerializeField] private StarRotation _starTemplate;
    [SerializeField] private Transform _starEndPoint;
    [SerializeField] private float _starSpeedMove;
    [SerializeField] private float _starRotationSpeed;
    [SerializeField] private GameObject _wings;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _titles;    

    [SerializeField] private CharacterFly _characterFly;

    private StarRotation star;
    private bool _starCreated;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_starCreated)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
            {
                star = Instantiate(_starTemplate, _starCreatePoint.position, Quaternion.identity);
                _starCreated = true;
                Instantiate(_wings, _starCreatePoint);
                Invoke(nameof(SetFly), 3f);
                Invoke(nameof(SetPanel), 10f);
                Invoke(nameof(SetTitles), 20);
            }
        }
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
            else
            {
                star.SetRotationSpeed(_starRotationSpeed);
            }
        }
    }

    private void SetFly()
    {
        _characterFly._fly = true;
        _characterFly.SetBodyKinematic();
    }

    private void SetPanel()
    {
        _panel.SetActive(true);
    }

    private void SetTitles()
    {
        _titles.SetActive(true);
    }
}
