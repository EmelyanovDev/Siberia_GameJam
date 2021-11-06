using UnityEngine;

namespace Game_Asset.Scripts.PostEffects
{
    public class GlitchFilter : SimpleFilter
    {
        [SerializeField, Range(0, 1f)] private float colorIntensity = 1f;
        [SerializeField, Range(0, 1)] private float noiseIntensity = 1f;
        [SerializeField, Range(0, 1)] private float flipIntensity = 1f;

        [SerializeField] private Texture2D noiseTexture;


        private float _flickerTimer;
        private float _flickerTime = 0.5f;
        
        private float _flipUpTimer;
        private float _flipUpTime = 0.05f;
        
        private float _flipDownTimer;
        private float _flipDownTime = 0.05f;
        
        
        private static readonly int FlipUp = Shader.PropertyToID("_FlipUp");
        private static readonly int FlipDown = Shader.PropertyToID("_FlipDown");
        private static readonly int NoiseTex = Shader.PropertyToID("_NoiseTex");
        private static readonly int NoiseScale = Shader.PropertyToID("_NoiseScale");
        private static readonly int ColorRadius = Shader.PropertyToID("_ColorRadius");
        private static readonly int ColorDirection = Shader.PropertyToID("_ColorDirection");
        private static readonly int DisplacementFactor = Shader.PropertyToID("_DisplacementFactor");

        protected override void UseFilter(RenderTexture src, RenderTexture dst)
        {
            _flipUpTimer += Time.deltaTime * flipIntensity;
            if (_flipUpTimer > _flipUpTime)
            {
                if (Random.value < 0.1f * flipIntensity)
                {
                    Material.SetFloat(FlipUp, Random.value * flipIntensity);
                }
                else
                {
                    Material.SetFloat(FlipUp, 0);
                }
                _flipUpTimer = 0;
                _flipUpTime = Random.value * 0.1f;
            }

            _flipDownTimer += Time.deltaTime * flipIntensity;
            if (_flipDownTimer > _flipDownTime)
            {
                if (Random.value < 0.1f * flipIntensity)
                {
                    Material.SetFloat(FlipDown, 1 - Random.value * flipIntensity);
                }
                else
                {
                    Material.SetFloat(FlipDown, 1);
                }
                _flipDownTimer = 0;
                _flipDownTime = Random.value * 0.1f;
            }
        
            if (flipIntensity == 0)
            {
                Material.SetFloat(FlipUp, 0);
                Material.SetFloat(FlipDown, 1);
            }
        
            Material.SetTexture(NoiseTex, noiseTexture);
            if (Random.value < 0.05 * noiseIntensity)
            {
                Material.SetFloat(DisplacementFactor, Random.value * noiseIntensity);
                Material.SetFloat(NoiseScale, 1 - Random.value - noiseIntensity);
            }
            else
            {
                Material.SetFloat(DisplacementFactor, 0);
            }
        
            _flickerTimer += Time.deltaTime * colorIntensity;
            if (_flickerTimer > _flickerTime)
            {
                Material.SetVector(ColorDirection, Random.insideUnitCircle);
                Material.SetFloat(ColorRadius, Random.Range(-3f, 3f) * 
                                               colorIntensity);
                _flickerTimer = 0;
                _flickerTime = Random.value;
            }

            if (colorIntensity == 0)
            {
                Material.SetFloat(ColorRadius, 0);
            }
            Graphics.Blit(src, dst, Material);
        }
    }
}
