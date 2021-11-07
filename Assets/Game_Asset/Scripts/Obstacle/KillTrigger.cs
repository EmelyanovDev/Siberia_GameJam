using UnityEngine;
using Game_Asset.Scripts.GameManager;

namespace Game_Asset.Scripts.Obstacle
{
    public class KillTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("TriggerInitiator")) return;
            GameMaster.Instance.OnDieCharacter(other.transform.parent);
        }
    }
}