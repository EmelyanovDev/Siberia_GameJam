using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

namespace Game_Asset.Scripts.SceneLoadSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(SceneList sceneIndex)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) sceneIndex, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = true;
        }

        public AsyncOperation LoadSceneAsync(SceneList sceneIndex)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) sceneIndex, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;
            return asyncLoad;
        }
    }
}