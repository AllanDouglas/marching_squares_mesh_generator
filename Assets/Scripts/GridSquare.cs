using System;

namespace MarchingSquare
{
    public class GridSquare
    {
        public readonly int rows;
        public readonly int columns;
        private readonly int[] vertices;

        public GridSquare(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            vertices = new int[rows * columns];
        }

        public void SetVertexValue(SquareVertex vertex, int value)
        {
            value = Math.Max(0, Math.Min(value, 1));
            vertices[GetIndex(vertex)] = value;
        }

        public int GetVertexValue(SquareVertex vertex) => GetVertexValue(GetIndex(vertex));

        private int GetVertexValue(int index)
        {
            if (index >= vertices.Length || index < 0)
                return 0;

            return vertices[index];
        }

        public int GetVertexValue(int x, int y) => GetVertexValue(new SquareVertex(x, y));
        private int GetIndex(SquareVertex vertex) => GetIndex(vertex.x, vertex.y);
        private int GetIndex(int x, int y) => (columns - 1) * y + x + y;
        public int GetSquareValue(Square square)
        {
            var p1 = GetVertexValue(square.p1) << 3;
            var p2 = GetVertexValue(square.p2) << 2;
            var p3 = GetVertexValue(square.p3) << 1;
            var p4 = GetVertexValue(square.p4);

            return p1 + p2 + p3 + p4;
        }

        internal Neighbors GetNeighbors(SquareVertex squareVertex)
        {
            var left = new SquareVertex(squareVertex.x - 1, squareVertex.y);
            var top = new SquareVertex(squareVertex.x, squareVertex.y + 1);
            var right = new SquareVertex(squareVertex.x + 1, squareVertex.y);
            var down = new SquareVertex(squareVertex.x, squareVertex.y - 1);

            return new Neighbors(
                 new Neighbor(left, GetVertexValue(left)),
                 new Neighbor(top, GetVertexValue(top)),
                 new Neighbor(right, GetVertexValue(right)),
                 new Neighbor(down, GetVertexValue(down))
             );
        }
    }

}