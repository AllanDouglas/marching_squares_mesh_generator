namespace MarchingSquare
{
    public struct SquareVertex
    {
        public readonly int x;
        public readonly int y;

        public SquareVertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{nameof(SquareVertex)} ({x},{y})";
    }

}