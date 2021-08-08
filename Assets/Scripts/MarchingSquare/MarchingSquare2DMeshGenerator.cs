using MeshCreatorHelper;
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
        IMeshVertexPool<MeshVertex> meshVertexPool)
        {

            var meshSquare = new MeshSquare(square, offset);
            var gridValue = grid.GetSquareValue(square);

            MarchingSquareMeshHelper.DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, in gridValue);           

        }

    }

}