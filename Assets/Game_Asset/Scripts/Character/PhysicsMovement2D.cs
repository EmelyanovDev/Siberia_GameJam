using System;
using UnityEngine;
using UnityEngine.Events;
#pragma warning disable 108,114

namespace Game_Asset.Scripts.Character
{
	public class PhysicsMovement2D : MonoBehaviour
	{
		[SerializeField] private Rigidbody2D rigidbody2D;
		[SerializeField] private float jumpForce = 400f;
		[Range(0, 1)] [SerializeField] private float crouchSpeed = 0.36f;
		[Range(0, .3f)] [SerializeField] private float movementSmoothing = 0.05f;
		[SerializeField] private bool airControl = false;
		[SerializeField] private LayerMask whatIsGround;
		[SerializeField] private Transform groundCheck;
		[SerializeField] private Transform ceilingCheck;
		[SerializeField] private Collider2D crouchDisableCollider;
		
		
		private const float GroundedRadius = 0.2f;
		private const float CeilingRadius = 0.2f;
		
		private Transform _selfTransform;
		private bool _grounded;
		private bool _facingRight = true;
		private Vector3 _velocity = Vector3.zero;

		public float Velocity => _velocity.magnitude;

		[Header("Events")]
		[Space]

		public UnityEvent onLandEvent;

		[System.Serializable]
		public class BoolEvent : UnityEvent<bool> { }

		public BoolEvent onCrouchEvent;
		private bool _wasCrouching = false;

		private void Awake()
		{
			_selfTransform = GetComponent<Transform>();
			
			if (!rigidbody2D) throw new NullReferenceException($"{nameof(rigidbody2D)} is null!");

			onLandEvent ??= new UnityEvent();
			onCrouchEvent ??= new BoolEvent();
		}

		private void FixedUpdate()
		{
			bool wasGrounded = _grounded;
			_grounded = false;
		
		
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, whatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					_grounded = true;
					if (!wasGrounded)
						onLandEvent.Invoke();
				}
			}
		}


		public void Move(float move, bool jump, bool crouch, Transform flipTransform)
		{
			if (crouch == false)
			{
				if (Physics2D.OverlapCircle(ceilingCheck.position, CeilingRadius, whatIsGround))
				{
					crouch = true;
				}
			}
		
			if (_grounded || airControl)
			{

				// If crouching
				if (crouch)
				{
					if (!_wasCrouching)
					{
						_wasCrouching = true;
						onCrouchEvent.Invoke(true);
					}
				
					move *= crouchSpeed;

					// Disable one of the colliders when crouching
					if (crouchDisableCollider != null) crouchDisableCollider.enabled = false;
				
				} else
				{
					// Enable the collider when not crouching
					if (crouchDisableCollider != null) crouchDisableCollider.enabled = true;

					if (_wasCrouching)
					{
						_wasCrouching = false;
						onCrouchEvent.Invoke(false);
					}
				}

			
				// Move the character
				Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

				rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref _velocity, movementSmoothing);
			
			
				if (move > 0 && _facingRight == false)
				{
					Flip(flipTransform);
				}
				else if (move < 0 && _facingRight)
				{
					Flip(flipTransform);
				}
			}

			if (!_grounded || !jump) return;
		
			// Add a vertical force to the player.
			_grounded = false;
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}

		public void Move(float move, bool jump, bool crouch)
		{
			Move(move, jump, crouch, _selfTransform);
		}


		private void Flip(Transform transformFlip)
		{
			_facingRight = !_facingRight;

		
			Vector3 theScale = transformFlip.localScale;
			theScale.x *= -1;
			transformFlip.localScale = theScale;
		}
	}
}
