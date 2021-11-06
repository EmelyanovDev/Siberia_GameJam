using System;
using UnityEngine;

namespace Game_Asset.Scripts.Utility
{
    public class DontDestroy : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(this.gameObject);
    }
}