using UnityEngine;
using UnityEngine.Events;

namespace Game_Asset.Scripts.Conundrums
{
    public class Trigger : MonoBehaviour
    {
        public bool IsTrigger;
        public UnityEvent triggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
            {
                IsTrigger = true;
                triggered?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
            {
                IsTrigger = false;
                triggered?.Invoke();
            }
        }
    }
}