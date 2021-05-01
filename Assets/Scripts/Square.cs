namespace MarchingSaquere
{
    public struct Square
    {
        public SquareVertex p1, p2, p3, p4;

        public Square(SquareVertex p1, SquareVertex p2,
            SquareVertex p3, SquareVertex p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

    }

}