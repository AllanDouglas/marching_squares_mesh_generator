using UnityEngine;

namespace MarchingSquare
{

    public partial class MarchingSquareMeshGenerator : IMarchingSaquereMeshGenerator
    {
        private int nextVertexIndex = 0;
        private int triangleIndex = 0;
        private readonly MeshVertexPool meshVertexPool = new MeshVertexPool();

        public Mesh GenerateMesh(GridSquare grid, float offset)
        {
            Reset();

            var triangles = new int[GetTotalOfTriangles(gridSquare: grid) * 3];

            for (int y = 1; y < grid.rows; y++)
            {
                for (int x = 0; x < grid.columns - 1; x++)
                {
                    var square = new Square(
                            new SquareVertex(x, y),
                            new SquareVertex(x + 1, y),
                            new SquareVertex(x + 1, y - 1),
                            new SquareVertex(x, y - 1)
                        );

                    EvaluateVertices(
                        grid: grid,
                        square: square,
                        offset: offset,
                        vertexIndex: ref nextVertexIndex,
                        triangleIndex: ref triangleIndex,
                        triangles: triangles,
                        meshVertexPool: meshVertexPool);
                }
            }

            var mesh = new Mesh();

            Vector3[] vertices = meshVertexPool.GetVertices();

            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);
            mesh.SetUVs(0, new Vector2[vertices.Length]);

            mesh.RecalculateNormals();

            return mesh;
        }

        private int GetTotalOfTriangles(GridSquare gridSquare)
        {
            var triangles = 0;
            for (int y = 1; y < gridSquare.rows; y++)
            {
                for (int x = 0; x < gridSquare.columns - 1; x++)
                {
                    var square = new Square(
                            new SquareVertex(x, y),
                            new SquareVertex(x + 1, y),
                            new SquareVertex(x + 1, y - 1),
                            new SquareVertex(x, y - 1)
                        );

                    triangles += GetAmountOfTrianglesFromSquare(gridSquare, square);
                }
            }

            return triangles;
        }

        private int GetAmountOfTrianglesFromSquare(GridSquare gridSquare, Square square) =>
            GetAmountOfTrianglesFromSquare(gridSquare.GetSquareValue(square));

        private int GetAmountOfTrianglesFromSquare(int value)
        {
            switch (value)
            {
                case 1:
                case 2:
                case 4:
                case 8:
                    return 1;
                case 3:
                case 6:
                case 9:
                case 12:
                case 15:
                    return 2;
                case 7:
                case 11:
                case 13:
                case 14:
                    return 3;
                case 5:
                case 10:
                    return 4;
                default:
                    return 0;
            }
        }

        private void Reset()
        {
            meshVertexPool.Clear();
            nextVertexIndex = 0;
            triangleIndex = 0;
        }

        private void EvaluateVertices(
            GridSquare grid,
            Square square,
            float offset,
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool
            )
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