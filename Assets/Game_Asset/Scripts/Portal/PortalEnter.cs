using System;
using Game_Asset.Scripts.SceneLoadSystem;
using UnityEngine;

namespace Game_Asset.Scripts.Portal
{
    public class PortalEnter : MonoBehaviour
    {
        public SceneList sceneList;
        public bool a = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TriggerInitiator") && !a)
            {
                a = false;
                SceneLoader.LoadScene((int) sceneList);
            }
        }
    }
}