using System;
using System.Collections;
using Game_Asset.Scripts.Character;
using Game_Asset.Scripts.CheckPoint;
using Game_Asset.Scripts.PostEffects;
using UnityEngine;
using UnityEngine.Events;

namespace Game_Asset.Scripts.GameManager
{
    public class GameMaster : MonoBehaviour
    {
        private static GameMaster _instance;
        public static GameMaster Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<GameMaster>();
                return _instance;
            }
        }

        public KeyboardInput keyboardInput;
        public VignetteFilter vignette;
        public GlitchFilter glitch;

        public bool allowControl = false;
        
        public UnityEvent controlAllowed;
        public UnityEvent controlDenied;
        public UnityEvent Died;

        private void Awake()
        {
            if (keyboardInput == null) enabled = false;
        }

        private void OnEnable()
        {
            if (!allowControl) DeniedControl();

        }

        public void AllowedControl()
        {
            keyboardInput.enabled = true;
            controlAllowed?.Invoke();
        }
        
        public void DeniedControl()
        {
            keyboardInput.enabled = false;
            controlAllowed?.Invoke();
        }
        

        public void OnDieCharacter(Transform character)
        {
            DeniedControl();
            glitch.useFilter = true;
            vignette.useFilter = true;
            StartCoroutine(Timer(1f, 0f, 40f, f =>
            {
                vignette.exp = f;
            }));

            StartCoroutine(Timer2(1f, () =>
            {
                StartCoroutine(Timer(2f, 40f, 0f, f =>
                {
                    vignette.exp = f;
                }));
            }));

            StartCoroutine(Timer2(3f, () =>
            {
                character.position = CheckPointsManager.Instance.GetLastCheckPoint();
                glitch.useFilter = false;
                vignette.useFilter = false;
                AllowedControl();
            }));
            
            Died?.Invoke();
        }


        IEnumerator Timer(float duration, float begin, float end, Action<float> target)
        {
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                target(Mathf.Lerp(begin, end, t / duration));
                yield return null;
            }
            target(end);
        }
        
        IEnumerator Timer2(float duration, Action target)
        {
            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                yield return null;
            }
            target();
        }
    }
}