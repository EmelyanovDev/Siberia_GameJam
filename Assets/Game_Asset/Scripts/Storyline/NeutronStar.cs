using UnityEngine;

namespace Game_Asset.Scripts.Storyline
{
    public class NeutronStar : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}
