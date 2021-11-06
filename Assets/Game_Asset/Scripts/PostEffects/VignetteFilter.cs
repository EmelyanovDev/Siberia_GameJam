using UnityEngine;

namespace Game_Asset.Scripts.PostEffects
{
    public class VignetteFilter : SimpleFilter
    {
        public Vector2 offset;
        public float exp;
        public Color color;

        private static readonly int xOffset = Shader.PropertyToID("_xOffset");
        private static readonly int yOffset = Shader.PropertyToID("_yOffset");
        private static readonly int Exp = Shader.PropertyToID("_Exp");
        private static readonly int Color = Shader.PropertyToID("_Color");


        protected override void UseFilter(RenderTexture src, RenderTexture dst)
        {
            Material.SetFloat(xOffset, offset.x);
            Material.SetFloat(yOffset, offset.y);
            Material.SetFloat(Exp, exp);
            Material.SetColor(Color, color);

            Graphics.Blit(src, dst, Material);
        }
    }
}