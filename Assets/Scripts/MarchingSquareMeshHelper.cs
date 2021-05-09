namespace MarchingSquare
{
    internal static class MarchingSquareMeshHelper
    {
        internal static void Fifteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        internal static void Fourteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        internal static void Thirteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.P4);
        }

        internal static void Twelve(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.D);
        }

        internal static void Eleven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        internal static void Ten(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        internal static void Nine(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.P1, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.C);
        }

        internal static void CreateTriangle(ref int vertexIndex,
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

        internal static void Six(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P2, meshSquare.P3, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.A);

        }

        internal static void Five(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.A, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
        }

        internal static void Seven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.P3);
        }

        internal static void Tree(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.B);
        }

        internal static void Eigth(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.D);
        }

        internal static void Four(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.B);
        }

        internal static void Two(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.B);
        }

        internal static void One(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.C);
        }

        internal static void EvaluateMeshVertex(ref int vertexIndex, int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshVertex meshVertex)
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