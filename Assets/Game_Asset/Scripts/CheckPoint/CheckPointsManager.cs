using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game_Asset.Scripts.CheckPoint
{
    public class CheckPointsManager : MonoBehaviour
    {
        private static CheckPointsManager _instance;
        public static CheckPointsManager Instance
        {
            get
            {
                if (_instance == null) _instance = GameObject.FindObjectOfType<CheckPointsManager>();
                return _instance;
            }
        }
        
        private List<CheckPoint> _checkPoints;
        private CheckPoint _lastCheckPoint;
        private void Awake()
        {
            _checkPoints = FindObjectsOfType<CheckPoint>().ToList();
            if (_checkPoints.Count == 0) throw new NullReferenceException("");
        }

        private void OnEnable()
        {
            foreach (var checkPoint in _checkPoints)
            {
                checkPoint.Activated += ActivatedCheckPoint;
            }
        }

        private void OnDisable()
        {
            foreach (var checkPoint in _checkPoints)
            {
                checkPoint.Activated -= ActivatedCheckPoint;
            }
        }

        private void ActivatedCheckPoint(CheckPoint a)
        {
            _lastCheckPoint = a;
        }

        public Vector3 GetLastCheckPoint()
        {
            return _lastCheckPoint.gameObject.transform.position + Vector3.up * 2f;
            print("SSSS");
        }
    }
}