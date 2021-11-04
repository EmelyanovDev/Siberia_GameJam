using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Game_Asset.Scripts.BackgroundSystem
{
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
    public class BackgroundSystem : MonoBehaviour
    {
        public string Names = "BGS";
        public BackgroundContainer Container;

        private readonly ObjectsPool<SpriteRenderer> _pool = new ObjectsPool<SpriteRenderer>();
        private readonly List<ObjectsPool<SpriteRenderer>> _layers = new List<ObjectsPool<SpriteRenderer>>();
        private Transform _selfTransform;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            if (!Container) throw new NullReferenceException("Container is null!");

            foreach (var layer in Container.layers)
            {
                var s = new GameObject("Layer");
                s.transform.parent = _selfTransform;
                var pull = new ObjectsPool<SpriteRenderer>();
                pull.InitialisationPull(layer.data.Count, Names, s.transform);

                for (int i = 0; i < pull.Count; i++)
                {
                    pull[i].sprite = layer[i].sprite;
                }
            }
        }

        private void OnBecameVisible()
        {
            print("ggg");
        }
    }
}