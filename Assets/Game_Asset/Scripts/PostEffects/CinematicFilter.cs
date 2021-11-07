using UnityEngine;

namespace Game_Asset.Scripts.PostEffects
{
    public class CinematicFilter : SimpleFilter
    {
        [Range(0f, 1f)] public float offset;
        public Color color;

        private static readonly int Offset = Shader.PropertyToID("_Offset");
        private static readonly int Color = Shader.PropertyToID("_Color");

        private float coff;
        const float dataCoff = 2.39f;
        internal override void Init()
        {
            float screenCoff = Screen.width / Screen.height;
            coff = 1 - (screenCoff / 2) / (dataCoff / 2);
        }

        protected override void UseFilter(RenderTexture src, RenderTexture dst)
        {
            Material.SetFloat(Offset, coff);
            Material.SetColor(Color, color);

            Graphics.Blit(src, dst, Material);
        }
    }
}