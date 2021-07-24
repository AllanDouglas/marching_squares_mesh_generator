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

        internal CrossNeighbors<Neighbor<Square>> GetNeighbors(Square center)
        {
            var leftSquare = Square.BuildSquare(
                leftTop: new SquareVertex(center.LeftTop.x - 1, center.LeftTop.y),
                rightTop: center.LeftTop,
                rightDown: center.LeftDown,
                leftDown: new SquareVertex(center.LeftDown.x - 1, center.LeftDown.y)
            );

            var topSquare = Square.BuildSquare(
                leftTop: new SquareVertex(center.LeftTop.x, center.LeftTop.y + 1),
                rightTop: new SquareVertex(center.RightTop.x, center.RightTop.y + 1),
                rightDown: center.RightTop,
                leftDown: center.LeftTop
            );

            var rightSquare = Square.BuildSquare(
                leftTop: new SquareVertex(center.RightTop.x + 1, center.RightTop.y),
                rightTop: center.RightTop,
                rightDown: center.RightDown,
                leftDown: new SquareVertex(center.RightDown.x + 1, center.RightDown.y)
            );

            var downSquare = Square.BuildSquare(
                leftTop: center.LeftDown,
                rightTop: center.RightDown,
                rightDown: new SquareVertex(center.RightDown.x, center.RightDown.y - 1),
                leftDown: new SquareVertex(center.LeftDown.x, center.LeftDown.y - 1)
            );

            return new CrossNeighbors<Neighbor<Square>>(
                new Neighbor<Square>(leftSquare, GetSquareValue(leftSquare)),
                new Neighbor<Square>(topSquare, GetSquareValue(topSquare)),
                new Neighbor<Square>(rightSquare, GetSquareValue(rightSquare)),
                new Neighbor<Square>(downSquare, GetSquareValue(downSquare))
            );
        }

        internal CrossNeighbors<Neighbor<SquareVertex>> GetNeighbors(SquareVertex squareVertex)
        {
            var left = new SquareVertex(squareVertex.x - 1, squareVertex.y);
            var top = new SquareVertex(squareVertex.x, squareVertex.y + 1);
            var right = new SquareVertex(squareVertex.x + 1, squareVertex.y);
            var down = new SquareVertex(squareVertex.x, squareVertex.y - 1);

            return new CrossNeighbors<Neighbor<SquareVertex>>(
                 new Neighbor<SquareVertex>(left, GetVertexValue(left)),
                 new Neighbor<SquareVertex>(top, GetVertexValue(top)),
                 new Neighbor<SquareVertex>(right, GetVertexValue(right)),
                 new Neighbor<SquareVertex>(down, GetVertexValue(down))
             );
        }
    }

}