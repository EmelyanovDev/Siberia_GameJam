using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace Game_Asset.Scripts.BackgroundSystem
{
    [SuppressMessage("ReSharper", "CollectionNeverQueried.Local")]
    public class ObjectsPool <TSource> where TSource : Component
    {
        private readonly List<TSource> _pool = new List<TSource>();
        private readonly List<GameObject> _gameObjectsPull = new List<GameObject>();
        
        public TSource this[int index] => _pool[index];
        public List<TSource> Pool => _pool;
        public int Count => _pool.Count;

        public ObjectsPool()
        {
            
        }
        
        public ObjectsPool(List<TSource> pool)
        {
            _pool = pool;
        }
        
        public ObjectsPool(IEnumerable<TSource> pool)
        {
            _pool = pool.ToList();
        }

        public void _AddObject(TSource element)
        {
            _pool.Add(element);
        }

        public void _RemoveObject(TSource element)
        {
            _pool.Remove(element);
        }

        public void InitialisationPull(int count, string name, Transform parent = null, bool enable = false)
        {
            for (int i = 0; i < count; i++)
            {
                _CreateGameObject(index: i, count, name, parent, enable);
            }
        }
        public void InitialisationPull(int count, string name, Action<TSource, int> callback, bool enable = false)
        {
            for (int i = 0; i < count; i++)
            {
                callback(_CreateGameObject(index: i, count, name, null, enable), i);
            }
        }
        
        public void InitialisationPull(int count, string name, Transform parent, Action<TSource, int> callback, bool enable = false)
        {
            for (int i = 0; i < count; i++)
            {
                callback(_CreateGameObject(index: i, count, name, parent, enable), i);
            }
        }

        private TSource _CreateGameObject(int index, int count, string name, Transform parent, bool enable)
        {
            var gameObject = new GameObject($"{name} {index + 1}");
            gameObject.transform.parent = parent;
            _gameObjectsPull.Add(gameObject);
                
            var tSource = gameObject.AddComponent<TSource>(); 
            _pool.Add(tSource);
            gameObject.SetActive(enable);
            return tSource;
        }
    }
}