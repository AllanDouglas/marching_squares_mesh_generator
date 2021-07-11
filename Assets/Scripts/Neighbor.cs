namespace MarchingSquare
{
    public struct Neighbor
    {
        public readonly SquareVertex vertex;
        public readonly int value;

        public Neighbor(SquareVertex vertex, int value)
        {
            this.vertex = vertex;
            this.value = value;
        }
    }

}