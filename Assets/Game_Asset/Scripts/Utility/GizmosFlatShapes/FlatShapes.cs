using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace GizmosFlatShapes
{
    public static class FlatShapes
    {
        public static List<Vector3> Polygon(uint edges, float radius, Vector3 center, float angleRotation)
        {
            List<Vector3> vertexes = new List<Vector3>();
            for (int i = 0; i < edges; i++)
            {
                float angle = (2f * Mathf.PI) / (float)edges * i + angleRotation * Mathf.PI / 180;
                vertexes.Add(new Vector3(
                    (Mathf.Cos(angle) * radius) + center.x, 
                    (Mathf.Sin(angle) * radius) + center.y,
                    center.z
                ));
            }
            return vertexes;
        }

        public static int Next(int index, int lenght)
        {
            return (++index) % lenght;
        }
    }
}