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
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 0, triangles, meshVertexPool, p1);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 1, triangles, meshVertexPool, p2);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 2, triangles, meshVertexPool, p3);

            triangleIndex += 3;
        }

        internal static void EvaluateMeshVertex(
            ref int vertexIndex,
            int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            MeshVertex meshVertex)
        {
            if (meshVertexPool.TryGetIndex(meshVertex, out int index))
            {
                triangles[triangleIndex] = index;
            }
            else
            {
                meshVertexPool.Add(meshVertex, vertexIndex);
                triangles[triangleIndex] = vertexIndex;
                vertexIndex++;
            }
        }
    }
}