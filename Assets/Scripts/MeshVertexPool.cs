using System.Collections.Generic;
using UnityEngine;

namespace MarchingSquare
{
    public sealed class MeshVertexPool
    {
        private VertexData[] arrayPool;
        private readonly Dictionary<MeshVertex, int> vertexPool = new Dictionary<MeshVertex, int>();
        private readonly Dictionary<VertexData, int> vertexDataPool = new Dictionary<VertexData, int>();
        public int Size => vertexDataPool.Count;
        public bool TryGetIndex(MeshVertex meshVertex, out int index) => vertexPool.TryGetValue(meshVertex, out index);
        public bool TryGetBufferIndex(MeshVertex meshVertex, out int index)
            => vertexDataPool.TryGetValue(new VertexData(meshVertex.position, Vector3.up), out index);
        public void Add(MeshVertex meshVertex, int index) => vertexPool.Add(meshVertex, index);
        public void Add(int index, MeshVertex meshVertex, MeshVertex normal)
        {
            vertexPool.Add(meshVertex, index);

            vertexDataPool.Add(new VertexData(
                position: meshVertex.position,
                normal: normal.position
            ), index);
        }

        public void Clear()
        {
            vertexPool.Clear();
            vertexDataPool.Clear();
        }

        public Vector3[] GetVertices()
        {
            var vertices = new Vector3[Size];

            foreach (var item in vertexPool)
            {
                vertices[item.Value] = item.Key.position;
            }

            return vertices;
        }

        public VertexBufferData GetVertexBufferData()
        {

            if (arrayPool is null || arrayPool.Length < Size)
            {
                arrayPool = new VertexData[Size];
            }

            foreach (var item in vertexDataPool)
            {
                arrayPool[item.Value] = item.Key;
            }

            var buffer = new VertexBufferData(
                data: arrayPool,
                start: 0,
                meshDataStart: 0,
                size: Size
            );

            return buffer;
        }

    }
}