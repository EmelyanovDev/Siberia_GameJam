using UnityEngine.Events;

namespace Game_Asset.Scripts.GameManager
{
    public interface IAccess
    {
        public UnityEvent Allowed { get; set; }
        public UnityEvent Denied { get; set; }
    }
}