using System;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global

namespace Game_Asset.Scripts.PostEffects
{
    public class SimpleFilter : MonoBehaviour
    {
        public Shader effectShader;
        protected Material Material;
        public bool useFilter = true;

        private void Awake()
        {
            Material = new Material(effectShader);
            Init();
        }

        internal virtual void Init()
        {

        }

        private void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            if (useFilter)
            {
                UseFilter(src, dst);
            }
            else
            { 
                Graphics.Blit(src, dst); 
            }
        }

        protected virtual void UseFilter(RenderTexture src, RenderTexture dst)
        {
            Graphics.Blit(src, dst, Material);
        }
    }
}