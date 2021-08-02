namespace MarchingSquare
{
    public readonly ref struct VertexBufferData
    {
        public readonly int start;
        public readonly int meshDataStart;
        public readonly int size;
        public readonly VertexData[] data;

        public VertexBufferData(int start, int meshDataStart, int size, VertexData[] data)
        {
            this.start = start;
            this.meshDataStart = meshDataStart;
            this.size = size;
            this.data = data;
        }
    }
}