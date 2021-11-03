using System.Collections.Generic;
using UnityEngine;

namespace Game_Asset.Scripts.BackgroundSystem
{
    [CreateAssetMenu(menuName = "BGS/Container")]
    public class BackgroundContainer : ScriptableObject
    {
        public List<BackgroundData> Data;
    }
}
