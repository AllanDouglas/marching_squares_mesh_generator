namespace MeshCreatorHelper
{
    public static class MeshHelper
    {
        public static void CreateTriangle(
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            IMeshVertexPool<MeshVertex> meshVertexPool,
            MeshVertex p1,
            MeshVertex p2,
            MeshVertex p3)
        {
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 0, triangles, meshVertexPool, p1);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 1, triangles, meshVertexPool, p2);
            EvaluateMeshVertex(ref vertexIndex, triangleIndex + 2, triangles, meshVertexPool, p3);

            triangleIndex += 3;
        }

        private static void EvaluateMeshVertex(
            ref int vertexIndex,
            int triangleIndex,
            int[] triangles,
            IMeshVertexPool<MeshVertex> meshVertexPool,
            MeshVertex meshVertex)
        {
            meshVertexPool.Add(meshVertex);
            triangles[triangleIndex] = vertexIndex;
            vertexIndex++;
        }
    }
}