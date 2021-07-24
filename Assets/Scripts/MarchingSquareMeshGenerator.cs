using MarchingSquare;
using UnityEngine;

namespace MarchingSquare
{
    public abstract class MarchingSquareMeshGenerator : IMarchingSquareMeshGenerator
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

        protected virtual int GetTotalOfTriangles(GridSquare gridSquare)
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

        protected virtual int GetAmountOfTrianglesFromSquare(GridSquare gridSquare, Square square) =>
            GetAmountOfTrianglesFromSquareValue(gridSquare.GetSquareValue(square));

        protected virtual int GetAmountOfTrianglesFromSquareValue(int value)
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

        protected virtual void Reset()
        {
            meshVertexPool.Clear();
            nextVertexIndex = 0;
            triangleIndex = 0;
        }

        protected abstract void EvaluateVertices(
            GridSquare grid,
            Square square,
            float offset,
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool
            );


    }
}