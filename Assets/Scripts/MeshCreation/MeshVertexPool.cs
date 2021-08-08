using System.Collections.Generic;
using UnityEngine;

namespace MeshCreatorHelper
{
    public sealed class MeshVertexPool : IMeshVertexPool<MeshVertex>
    {
        private VertexData[] arrayPool;
        private readonly LinkedList<MeshVertex> meshVerticesPool = new LinkedList<MeshVertex>();
        public int Size => meshVerticesPool.Count;
        public int Add(MeshVertex meshVertex)
        {
            meshVerticesPool.AddLast(meshVertex);
            return Size - 1;
        }

        public void Clear() => meshVerticesPool.Clear();

        public Vector3[] GetVertices()
        {
            var vertices = new Vector3[Size];
            var index = 0;
            foreach (var item in meshVerticesPool)
            {
                vertices[index] = item.position;
                index++;
            }

            return vertices;
        }

        public VertexBufferData GetVertexBufferData()
        {

            if (arrayPool is null || arrayPool.Length < Size)
            {
                arrayPool = new VertexData[Size];
            }
            var index = 0;
            foreach (var item in meshVerticesPool)
            {
                arrayPool[index] = new VertexData(
                        position: item.position,
                        normal: item.normal
                    );
                index++;
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