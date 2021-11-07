using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Asset.Scripts.SceneLoadSystem
{
    public static class SceneLoader
    {
        public static void LoadScene(int sceneIndex)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = true;
        }

        public static AsyncOperation LoadSceneAsync(int sceneIndex)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
            asyncLoad.allowSceneActivation = false;
            return asyncLoad;
        }
    }
}