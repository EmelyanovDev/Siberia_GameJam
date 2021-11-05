using System;
using UnityEngine;

namespace Game_Asset.Scripts.Conundrums.Walls
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private Wall[] _controlledWalls;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))
                OnButtonClick();
        }

        public void OnButtonClick()
        {
            foreach (var controlledWall in _controlledWalls)
            {
                controlledWall.SetTargetPosition();
            }
        }
    }
}
