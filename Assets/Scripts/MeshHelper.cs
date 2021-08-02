using UnityEngine;

namespace MarchingSquare
{
    internal static class MeshHelper
    {
        internal static void CreateTriangle(
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            MeshVertex p1,
            MeshVertex p2,
            MeshVertex p3)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, p1, p2, p3, Vector3.up);
        }

        internal static void CreateTriangle(
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            MeshVertex p1,
            MeshVertex p2,
            MeshVertex p3,
            Vector3 normal)
        {
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 0, triangles, meshVertexPool, p1, normal);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 1, triangles, meshVertexPool, p2, normal);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 2, triangles, meshVertexPool, p3, normal);

            triangleIndex += 3;
        }

        private static void EvaluateMeshVertex(
            ref int vertexIndex,
            int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            MeshVertex meshVertex,
            Vector3 normal)
        {
            if (meshVertexPool.TryGetBufferIndex(meshVertex, out int index))
            {
                triangles[triangleIndex] = index;
                return;
            }
            meshVertexPool.Add(vertexIndex, meshVertex, new MeshVertex(normal));
            triangles[triangleIndex] = vertexIndex;
            vertexIndex++;

        }
    }
}