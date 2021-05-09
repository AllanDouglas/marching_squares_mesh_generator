using UnityEngine;
using System.Collections.Generic;

namespace MarchingSquare
{
    public sealed class MeshVertexPool
    {
        private readonly Dictionary<MeshVertex, int> pool = new Dictionary<MeshVertex, int>();
        public int Size => pool.Count;
        public bool TryGetIndex(MeshVertex meshVertex, out int index) => pool.TryGetValue(meshVertex, out index);
        public void Add(MeshVertex meshVertex, int index) => pool.Add(meshVertex, index);
        public void Clear() => pool.Clear();
        public Vector3[] GetVertices()
        {
            var vertices = new Vector3[Size];

            foreach (var item in pool)
            {
                vertices[item.Value] = item.Key.position;
            }

            return vertices;
        }
    }
}