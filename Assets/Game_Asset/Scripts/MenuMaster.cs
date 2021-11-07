using Game_Asset.Scripts.SceneLoadSystem;
using UnityEngine;

namespace Game_Asset.Scripts
{
    public class MenuMaster : MonoBehaviour
    {
        public void SceneLoad(int intex)
        {
            SceneLoader.LoadScene(intex);
        }

        public void OpenCanvas(Canvas canvas)
        {
            canvas.enabled = true;
        }
        
        public void CloseCanvas(Canvas canvas)
        {
            canvas.enabled = false;
        }

        public void Quit()
        {
            Application.Quit();
        }
        
    }
}
