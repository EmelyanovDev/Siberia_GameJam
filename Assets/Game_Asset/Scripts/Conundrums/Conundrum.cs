using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums
{
    public abstract class Conundrum : MonoBehaviour
    {
        public abstract void Activate();

        public abstract void Reset();
    }
}