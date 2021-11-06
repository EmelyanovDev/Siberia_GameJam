using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class Trigger : MonoBehaviour
    {
        public bool IsTrigger;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
                IsTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator"))
                IsTrigger = false;
        }
    }
}