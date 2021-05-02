using System;

namespace MarchingSquare
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
    }

}