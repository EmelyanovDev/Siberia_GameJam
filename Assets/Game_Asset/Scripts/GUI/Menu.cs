using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Asset.Scripts.GUI
{   
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject _info;
        [SerializeField] private GameObject _options;
        public void OnRestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void SetInfo()
        {
            _info.SetActive(!_info.activeSelf);
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void SetOptions()
        {
            _options.SetActive(!_options.activeSelf);
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
