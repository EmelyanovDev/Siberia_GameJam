using Game_Asset.Scripts.SceneLoadSystem;
using UnityEngine;

namespace Game_Asset.Scripts.GUI
{
    public class Exit : MonoBehaviour
    {
        public void ExitLevel(int A)
        {
            SceneLoader.LoadScene(A);
        }
    }
}
