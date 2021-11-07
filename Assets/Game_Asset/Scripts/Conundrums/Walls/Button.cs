using UnityEngine;

namespace Game_Asset.Scripts.Conundrums.Walls
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private Conundrum[] controlled;
        [SerializeField] private Trigger _trigger;
        [SerializeField] private AudioSource _clickSound;
        
        private void OnMouseDown()
        {
            if (!_trigger.IsTrigger) return;
            _clickSound.Play();
            foreach (var element in controlled) 
                element.Activate();
        }
    }
}
