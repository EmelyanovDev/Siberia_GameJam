using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class StoneTrigger : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _stoneRigidBody;
        [SerializeField] private AudioSource _activateSound;
        private bool _isActivate;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActivate)
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
                {
                    _stoneRigidBody.bodyType = RigidbodyType2D.Dynamic;
                    _activateSound.Play();
                }

                _isActivate = true;
            }
            
        }
    }
}