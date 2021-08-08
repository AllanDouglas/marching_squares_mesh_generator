using System.Collections.Generic;
using UnityEngine;

namespace MeshCreatorHelper
{
    public struct SharedMeshData
    {
        public readonly int index;
        public readonly MeshVertex meshVertex;

        public SharedMeshData(int index, MeshVertex meshVertex)
        {
            this.index = index;
            this.meshVertex = meshVertex;
        }
    }

    public sealed class MeshSharedVertexPool : IMeshVertexPool<SharedMeshData>
    {
        private VertexData[] arrayPool;
        private readonly Dictionary<MeshVertex, int> vertexPool = new Dictionary<MeshVertex, int>();
        private readonly Dictionary<VertexData, int> vertexDataPool = new Dictionary<VertexData, int>();
        public int Size => vertexDataPool.Count;

        public bool TryGetBufferIndex(MeshVertex meshVertex, out int index)
            => vertexDataPool.TryGetValue(new VertexData(meshVertex.position, Vector3.up), out index);

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

        public int Add(SharedMeshData data)
        {
            if (TryGetBufferIndex(data.meshVertex, out var index))
            {
                return index;
            }

            vertexPool.Add(data.meshVertex, data.index);

            vertexDataPool.Add(new VertexData(
                position: data.meshVertex.position,
                normal: data.meshVertex.normal
            ), data.index);

            return Size - 1;
        }
    }
}