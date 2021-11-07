using System;
using System.Collections;
using Game_Asset.Scripts.PostEffects;
using UnityEngine;

namespace Game_Asset.Scripts.Storyline
{
    public class NeutronStar : MonoBehaviour
    {
        [SerializeField] private VignetteFilter _vignetteFilter;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("TriggerInitiator")) return;
            _vignetteFilter.useFilter = true;
            StartCoroutine(Timer(1f, 0f, 40f, f =>
            {
                _vignetteFilter.exp = f;
            }));

            StartCoroutine(Timer2(1f, () =>
            {
                StartCoroutine(Timer(1f, 40f, 0f, f =>
                {
                    _vignetteFilter.exp = f;
                }));
            }));
            StartCoroutine(Timer2(2f, () =>
            {
                _vignetteFilter.useFilter = false;
                Destroy(gameObject);
            }));
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
    }
}
