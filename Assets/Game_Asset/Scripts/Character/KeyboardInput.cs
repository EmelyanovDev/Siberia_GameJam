using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game_Asset.Scripts.Character
{
    public class KeyboardInput : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement2D physicsMovement2D;
        [SerializeField] private Transform flipTransform;
        [SerializeField] private float speed = 40f;

        private float _direction;
        private bool _jump;
        private bool _crouch;
        private void Update()
        {
            _direction = Input.GetAxis(Axis.Horizontal) * speed;
            
            if (Input.GetButtonDown(Axis.Jump)) _jump = true;
            
            if (Input.GetButtonDown(Axis.Crouch)) _crouch = true;
            else if (Input.GetButtonUp(Axis.Crouch)) _crouch = false;
        }

        private void FixedUpdate()
        {
            physicsMovement2D.Move(_direction * Time.fixedDeltaTime, _jump, _crouch, flipTransform);
            _jump = false;
        }
    }
}