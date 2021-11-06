using System;
using System.Collections;
using Game_Asset.Scripts.PostEffects;
using UnityEngine;

namespace Game_Asset.Scripts.Character.SumuSystem
{
    public class SymuSystem : MonoBehaviour
    {
        public float Sumu = 0f;

        //[SerializeField] private float duration = 1f;
        //[SerializeField] private float addSum = 1f;
        [SerializeField] private GlitchFilter glitchFilter;
        
        private void AppSumu(float sum)
        {
            if(Sumu + sum < 0) return;
            Sumu += sum;
        }

        private void Update()
        {
            float _direction = Input.GetAxis(Axis.Horizontal);
        }


        private IEnumerator MoveTween(float durationF)
        {
            float t = 0f;
            while (t < durationF)
            {
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}