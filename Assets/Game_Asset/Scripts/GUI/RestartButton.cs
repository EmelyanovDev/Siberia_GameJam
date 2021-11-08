using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Asset.Scripts.GUI
{
    public class RestartButton : MonoBehaviour
    {
        public void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}