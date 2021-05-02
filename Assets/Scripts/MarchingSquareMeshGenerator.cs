using UnityEngine;
using System.Collections.Generic;

namespace MarchingSquare
{

    public class MarchingSquareMeshGenerator : IMarchingSaquereMeshGenerator
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

                    ExtractVertices(
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

        private void ExtractVertices(
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
                    Eigth(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
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

        private void Fifteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        private void Fourteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        private void Thirteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.P4);
        }

        private void Twelve(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.D);
        }

        private void Eleven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        private void Ten(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        private void Nine(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.P1, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.C);
        }

        private void CreateTriangle(ref int vertexIndex,
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

        private void Six(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P2, meshSquare.P3, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.A);

        }

        private void Five(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.A, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
        }

        private void Seven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.P3);
        }

        private void Tree(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.B);
        }

        private void Eigth(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.D);
        }

        private void Four(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.B);
        }

        private void Two(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.B);
        }

        private void One(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.C);
        }

        private void EvaluateMeshVertex(ref int vertexIndex, int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshVertex meshVertex)
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

        private class MeshVertexPool
        {
            private readonly Dictionary<MeshVertex, int> pool = new Dictionary<MeshVertex, int>();
            public int Size => pool.Count;
            public bool TryGetIndex(MeshVertex meshVertex, out int index) => pool.TryGetValue(meshVertex, out index);
            public void Add(MeshVertex meshVertex, int index) => pool.Add(meshVertex, index);
            public void Clear() => pool.Clear();
            public Vector3[] GetVertices()
            {
                var vertices = new Vector3[Size];

                foreach (var item in pool)
                {
                    vertices[item.Value] = item.Key.position;
                }

                return vertices;
            }
        }

    }

}