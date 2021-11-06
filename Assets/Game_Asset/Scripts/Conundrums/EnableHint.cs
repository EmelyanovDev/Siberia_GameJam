using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public class EnableHint : MonoBehaviour
    {
        [SerializeField] private Trigger trigger;
        [SerializeField] private HintAnimation hintAnimation;

        private void OnEnable()
        {
            trigger.triggered.AddListener(Switch);
        }

        private void OnDisable()
        {
            trigger.triggered.RemoveListener(Switch);
        }
        
        private void Switch()
        {
            hintAnimation.gameObject.SetActive(trigger.IsTrigger);
        }
    }
}