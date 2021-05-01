using UnityEngine;
using System.Collections.Generic;

namespace MarchingSaquere
{

    public static class MarchingSquareMeshGenerator
    {
        private static int nextVertexIndex = 0;
        private static int triangleIndex = 0;
        private static readonly MeshVertexPool meshVertexPool = new MeshVertexPool();

        public static Mesh GenerateMesh(GridSquare grid, Matrix4x4 matrix, float offset)
        {
            Reset();

            var triangles = new int[grid.GetTotalOfTriangles() * 3];

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

                    ExtractVertices(grid, square, offset, ref nextVertexIndex, ref triangleIndex, triangles, meshVertexPool, matrix);
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

        private static void Reset()
        {
            meshVertexPool.Clear();
            nextVertexIndex = 0;
            triangleIndex = 0;
        }

        private static void ExtractVertices(
            GridSquare grid,
            Square square,
            float offset,
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            Matrix4x4 matrix)
        {

            var meshSquare = new MeshSquare(square, offset, matrix);
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

        private static void Fifteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        private static void Fourteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        private static void Thirteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.P4);
        }

        private static void Twelve(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P2, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.D);
        }

        private static void Eleven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.P4);
        }

        private static void Ten(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.B, meshSquare.P3);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.P3, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.C, meshSquare.D);
        }

        private static void Nine(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.P1, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.C);
        }

        private static void CreateTriangle(ref int vertexIndex,
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

        private static void Six(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P2, meshSquare.P3, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.A);

        }

        private static void Five(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            Four(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.B, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.A, meshSquare.C);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
        }

        private static void Seven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.A);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.P3);
        }

        private static void Tree(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.P4, meshSquare.B);
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.B);
        }

        private static void Eigth(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P1, meshSquare.A, meshSquare.D);
        }

        private static void Four(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.A, meshSquare.P2, meshSquare.B);
        }

        private static void Two(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P3, meshSquare.C, meshSquare.B);
        }

        private static void One(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare)
        {
            CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare.P4, meshSquare.D, meshSquare.C);
        }

        private static void EvaluateMeshVertex(ref int vertexIndex, int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshVertex meshVertex)
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