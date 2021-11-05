using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Asset.Scripts.BackgroundSystem
{
    [Serializable]
    [CreateAssetMenu(menuName = "BGS/Layer")]
    public class BackgroundLayer : ScriptableObject
    {
        public List<BackgroundData> data;
        public Vector3 position;
        public float slowerBy = 100;
        
        
        public BackgroundData this[int index] => data[index];
    }
}