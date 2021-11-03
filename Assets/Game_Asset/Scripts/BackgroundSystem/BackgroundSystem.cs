using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Asset.Scripts.BackgroundSystem
{
    public class BackgroundSystem : MonoBehaviour
    {
        public string Names = "BGS";
        public BackgroundContainer Container;

        private readonly ObjectsPull<SpriteRenderer> _pull = new ObjectsPull<SpriteRenderer>();
        private Transform _selfTransform;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            if (!Container) throw new NullReferenceException("Container is null!");

            for (int i = 0; i < Container.Data.Count; i++)
            {
                GameObject go = new GameObject($"{Names} {i + 1}");
                go.transform.parent = _selfTransform;
                
                go.AddComponent<SpriteRenderer>();
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = Container.Data[i].sprite;

                _pull.AddObject(sr);
                
            }
        }
    }
}