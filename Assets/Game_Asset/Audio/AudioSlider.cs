using UnityEngine;
using UnityEngine.Audio;

namespace Game_Asset.Audio
{
    public class AudioSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;


        public void Master(float volume)
        {
            audioMixer.SetFloat("Master", volume);
        }
    
        public void Sound(float volume)
        {
            audioMixer.SetFloat("Sound", volume);
        }
    
        public void Music(float volume)
        {
            audioMixer.SetFloat("Music", volume);
        }
    
        public void OtherSound(float volume)
        {
            audioMixer.SetFloat("OtherSound", volume);
        }
    }
}