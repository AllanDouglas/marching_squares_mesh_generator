using System;

namespace MarchingSquare
{
    public struct Neighbors
    {
        public readonly Neighbor p1, p2, p3, p4;
        public readonly int Count;

        public Neighbors(Neighbor p1, Neighbor p2, Neighbor p3, Neighbor p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            Count = 4;
        }

        public Neighbor this[int index] => Get(index);

        public Neighbor Get(int index)
        {
            switch (index)
            {
                case 0:
                    return p1;
                case 1:
                    return p2;
                case 2:
                    return p3;
                case 3:
                    return p4;
                default:
                    throw new IndexOutOfRangeException();
            }

        }
    }

}