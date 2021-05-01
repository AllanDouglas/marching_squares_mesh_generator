using System;

namespace MarchingSaquere
{
    public class GridSquare
    {
        public readonly int rows;
        public readonly int columns;
        private int[] vertexs;

        public GridSquare(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            vertexs = new int[rows * columns];
        }

        public void SetVeterxValue(SquareVertex vertex, int value)
        {
            value = Math.Max(0, Math.Min(value, 1));
            vertexs[GetIndex(vertex)] = value;
        }

        public int GetVertexValue(SquareVertex vertex) => vertexs[GetIndex(vertex)];
        public int GetVertexValue(int x, int y) => GetVertexValue(new SquareVertex(x, y));
        private int GetIndex(SquareVertex vertex) => (columns - 1) * vertex.y + vertex.x + vertex.y;

        public int GetSquareValue(Square square)
        {
            var p1 = GetVertexValue(square.p1) << 3;
            var p2 = GetVertexValue(square.p2) << 2;
            var p3 = GetVertexValue(square.p3) << 1;
            var p4 = GetVertexValue(square.p4);

            return p1 + p2 + p3 + p4;
        }

        public int GetTotalOfTriangles()
        {
            var triangles = 0;
            for (int y = 1; y < rows; y++)
            {
                for (int x = 0; x < columns - 1; x++)
                {
                    var square = new Square(
                            new SquareVertex(x, y),
                            new SquareVertex(x + 1, y),
                            new SquareVertex(x + 1, y - 1),
                            new SquareVertex(x, y - 1)
                        );

                    triangles += GetAmountOfTrianglesFromSquare(square);
                }
            }

            return triangles;
        }

        public int GetAmountOfTrianglesFromSquare(Square square)
        {
            var value = GetSquareValue(square);

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

    }

}