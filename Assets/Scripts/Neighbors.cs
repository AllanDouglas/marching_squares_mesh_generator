using System;

namespace MarchingSquare
{
    public struct CrossNeighbors<T>
    {
        public readonly T left, top, right, bottom;
        public readonly int Count;

        public CrossNeighbors(T left, T top, T right, T down)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = down;
            Count = 4;
        }

        public T this[int index] => Get(index);

        public T Get(int index)
        {
            switch (index)
            {
                case 0:
                    return left;
                case 1:
                    return top;
                case 2:
                    return right;
                case 3:
                    return bottom;
                default:
                    throw new IndexOutOfRangeException();
            }

        }
    }

}