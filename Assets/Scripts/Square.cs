using System;

namespace MarchingSquare
{
    public struct Square
    {
        public static Square BuildSquare(
            SquareVertex leftTop,
            SquareVertex rightTop,
            SquareVertex rightDown,
            SquareVertex leftDown
            ) => new Square(leftTop, rightTop, rightDown, leftDown);

        public readonly SquareVertex p1, p2, p3, p4;
        public SquareVertex LeftTop => p1;
        public SquareVertex LeftDown => p4;
        public SquareVertex RightTop => p2;
        public SquareVertex RightDown => p3;
        public int AmountOfVertices => 4;

        ///<summary>Create a new Square</summary>
        /// <param name="p1">Left-Top corner</param>
        /// <param name="p2">Right-Top corner</param>
        /// <param name="p3">Right-Down Corner</param>
        /// <param name="p4">Left-Down Corner</param>
        public Square(SquareVertex p1, SquareVertex p2,
            SquareVertex p3, SquareVertex p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }
        public SquareVertex this[int index] => GetSquareVertex(index);
        private readonly SquareVertex GetSquareVertex(int index)
        {
            switch (index)
            {
                case 0: return p1;
                case 1: return p2;
                case 2: return p3;
                case 3: return p4;
                default: throw new IndexOutOfRangeException();
            }
        }
    }

}