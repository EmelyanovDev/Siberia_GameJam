using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private Conundrum[] controlled;

        public void OnButtonClick()
        {
            foreach (var element in controlled) 
                element.Activate();
        }
    }
}
