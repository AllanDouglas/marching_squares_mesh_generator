using MeshCreatorHelper;

namespace MarchingSquare
{

    internal static class MarchingSquareMeshHelper
    {

        internal static void DrawFace(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare, in int gridValue)
        {
            switch (gridValue)
            {
                case 1:
                    One(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 2:
                    Two(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 3:
                    Tree(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 4:
                    Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 5:
                    Five(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 6:
                    Six(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 7:
                    Seven(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 8:
                    Eight(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 9:
                    Nine(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 10:
                    Ten(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 11:
                    Eleven(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 12:
                    Twelve(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 13:
                    Thirteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 14:
                    Fourteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 15:
                    Fifteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
            }
        }
        internal static void Fifteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        internal static void Fourteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        internal static void Thirteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.P4);
        }

        internal static void Twelve(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.D);
        }

        internal static void Eleven(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        internal static void Ten(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        internal static void Nine(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.P1, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.C);
        }

        internal static void Six(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P2, meshSquare.P3, meshSquare.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.A);

        }

        internal static void Five(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.B, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.A, meshSquare.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
        }

        internal static void Seven(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.P3);
        }

        internal static void Tree(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.B);
        }

        internal static void Eight(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.D);
        }

        internal static void Four(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.B);
        }

        internal static void Two(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.B);
        }

        internal static void One(ref int vertexIndex, ref int triangleIndex, int[] triangles, IMeshVertexPool<MeshVertex> meshVertexPool, MeshSquare meshSquare)
        {
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.C);
        }
    }
}