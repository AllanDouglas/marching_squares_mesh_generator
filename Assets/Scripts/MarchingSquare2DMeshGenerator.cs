using UnityEngine;

namespace MarchingSquare
{

    public sealed class MarchingSquare2DMeshGenerator : MarchingSquareMeshGenerator
    {
        protected override void EvaluateVertices(
        GridSquare grid,
        Square square,
        float offset,
        ref int vertexIndex,
        ref int triangleIndex,
        int[] triangles,
        MeshVertexPool meshVertexPool)
        {

            var meshSquare = new MeshSquare(square, offset);
            var gridValue = grid.GetSquareValue(square);

            switch (gridValue)
            {
                case 1:
                    MarchingSquareMeshHelper.One(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 2:
                    MarchingSquareMeshHelper.Two(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 3:
                    MarchingSquareMeshHelper.Tree(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 4:
                    MarchingSquareMeshHelper.Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 5:
                    MarchingSquareMeshHelper.Five(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 6:
                    MarchingSquareMeshHelper.Six(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 7:
                    MarchingSquareMeshHelper.Seven(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 8:
                    MarchingSquareMeshHelper.Eigth(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 9:
                    MarchingSquareMeshHelper.Nine(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 10:
                    MarchingSquareMeshHelper.Ten(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 11:
                    MarchingSquareMeshHelper.Eleven(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 12:
                    MarchingSquareMeshHelper.Twelve(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 13:
                    MarchingSquareMeshHelper.Thirteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 14:
                    MarchingSquareMeshHelper.Fourteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
                case 15:
                    MarchingSquareMeshHelper.Fifteen(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
                    break;
            }

        }

    }

}