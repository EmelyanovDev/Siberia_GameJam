using System;
using UnityEngine;

namespace Game_Asset.Scripts.Character
{
    public class CharacterState : MonoBehaviour
    {
        //[SerializeField] private KeyboardInput keyboardInput;

        private void Awake()
        {
            //if (keyboardInput == null) throw new NullReferenceException("");
        }

        public void Die()
        {
            //keyboardInput.enabled = false;
        }
    }
}