using YamlDotNet.Core.Tokens;

namespace MarchingSquare
{
    public struct Neighbor<T>
    {
        public readonly T vertex;
        public readonly int value;

        public Neighbor(T vertex, int value)
        {
            this.vertex = vertex;
            this.value = value;
        }

        public override string ToString() => $"{vertex}: {value}";
    
    }

}