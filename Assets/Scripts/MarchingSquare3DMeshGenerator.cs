namespace MarchingSquare
{
    public class MarchingSquare3DMeshGenerator : MarchingSquareMeshGenerator
    {

        private enum Side
        {
            LEFT = 0, TOP, RIGHT, BOTTOM
        }

        private const Side LEFT = Side.LEFT;
        private const Side RIGHT = Side.RIGHT;
        private const Side FRONT = Side.BOTTOM;
        private const Side BACK = Side.TOP;

        protected override int GetAmountOfTrianglesFromSquare(GridSquare gridSquare, Square square)
        {
            return base.GetAmountOfTrianglesFromSquare(gridSquare, square);
        }

        protected override int GetAmountOfTrianglesFromSquareValue(int value)
        {
            int result = base.GetAmountOfTrianglesFromSquareValue(value);

            switch (value)
            {
                case 1:
                case 2:
                case 4:
                case 8:
                    result += 6;
                    break;
                case 5:
                case 10:
                    result += 12;
                    break;
                case 7:
                case 11:
                case 13:
                case 14:
                    result += 10;
                    break;
                case 3:
                case 6:
                case 9:
                case 12:
                case 15:
                    result += 8;
                    break;
            }

            return result;
        }

        protected override void EvaluateVertices(
           GridSquare grid,
           Square square,
           float offset,
           ref int vertexIndex,
           ref int triangleIndex,
           int[] triangles,
           MeshVertexPool vertexPool
           )
        {
            var cube = new MeshCube(square, offset);
            var meshSquare = cube.Up;
            var value = grid.GetSquareValue(square);

            var neighbors = grid.GetNeighbors(square);

            switch (value)
            {
                case 1:
                    One(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 2:
                    Two(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 3:
                    Three(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 4:
                    Four(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 5:
                    Five(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 6:
                    Six(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 7:
                    Seven(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 8:
                    Eight(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 9:
                    Nine(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 10:
                    Ten(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 11:
                    Eleven(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 12:
                    Twelve(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 13:
                    Thirteen(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 14:
                    Fourteen(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
                case 15:
                    Fifteen(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube, meshSquare, value, in neighbors);
                    break;
            }

        }

        private static void Fourteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 15, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 15, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 6, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 9, in value, LEFT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.C, cube.Front.C, cube.Left.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left.C, cube.Up.D, cube.Up.C);
        }

        private static void Thirteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 15, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 15, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 9, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 6, in value, RIGHT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front.C, cube.Front.A, cube.Right.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right.A, cube.Right.C, cube.Front.C);
        }

        private static void Twelve(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 15, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 9, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 6, in value, RIGHT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.D, cube.Up.B, cube.Right.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.D, cube.Right.C, cube.Left.C);
        }

        private static void Eleven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 15, in value, Side.LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 15, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 6, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 9, in value, Side.RIGHT, in neighbors);

            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.A, cube.Back.C, cube.Up.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Right.C, cube.Up.B);
        }

        private static void Ten(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 6, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 9, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 6, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 9, in value, LEFT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.C, cube.Front.C, cube.Left.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left.C, cube.Up.D, cube.Up.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.A, cube.Back.C, cube.Up.B);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Right.C, cube.Up.B);
        }

        private static void Fifteen(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 15, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 15, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 15, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 15, in value, RIGHT, in neighbors);
        }

        private static void Nine(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 9, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 15, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 6, in value, BACK, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front.C, cube.Up.C, cube.Up.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.A, cube.Back.C, cube.Front.C);
        }

        private static void Six(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 15, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 6, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 9, in value, BACK, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front.C, cube.Back.C, cube.Up.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Up.A, cube.Up.C, cube.Front.C);
        }

        private static void Five(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 6, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 9, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 6, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 9, in value, FRONT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Left.A, cube.Left.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Back.A, cube.Left.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front.C, cube.Front.A, cube.Right.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right.A, cube.Right.C, cube.Front.C);
        }

        private static void Eight(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 9, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 6, in value, BACK, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Left.C, cube.Left.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left.A, cube.Back.A, cube.Back.C);
        }

        private static void Seven(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool vertexPool, MeshCube cube, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Right, 15, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Front, 15, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Left, 6, in value, LEFT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back, 9, in value, BACK, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Left.A, cube.Left.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, vertexPool, cube.Back.C, cube.Back.A, cube.Left.A);
        }

        private static void Four(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshCube cubeMesh, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Back, 9, in value, BACK, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Right, 6, in value, RIGHT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Back.C, cubeMesh.Back.A, cubeMesh.Right.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Back.C, cubeMesh.Right.A, cubeMesh.Right.C);
        }

        private static void Three(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshCube cubeMesh, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Front, 15, in value, FRONT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Right, 9, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Left, 6, in value, LEFT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Right.C, cubeMesh.Right.A, cubeMesh.Left.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Right.C, cubeMesh.Left.A, cubeMesh.Left.C);
        }

        private static void Two(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshCube cubeMesh, MeshSquare meshSquare, int value, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Right, 9, in value, RIGHT, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Front, 6, in value, FRONT, in neighbors);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Front.C, cubeMesh.Right.A, cubeMesh.Front.A);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Front.C, cubeMesh.Right.C, cubeMesh.Right.A);
        }

        private static void One(
            ref int vertexIndex,
            ref int triangleIndex,
            int[] triangles,
            MeshVertexPool meshVertexPool,
            MeshCube cubeMesh,
            MeshSquare meshSquare,
            int value,
            in CrossNeighbors<Neighbor<Square>> neighbors)
        {

            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, in value);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Front, 9, value, Side.BOTTOM, in neighbors);
            DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, cubeMesh.Left, 6, value, Side.LEFT, in neighbors);

            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool,
                cubeMesh.Front.A, cubeMesh.Left.A, cubeMesh.Front.C);
            MeshHelper.CreateTriangle(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool,
                cubeMesh.Front.C, cubeMesh.Left.A, cubeMesh.Left.C);
        }

        private static bool HasNoNeighbor(in int center, in int other) => (center & other) == 0;

        private static void DrawFace(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare, in int value, in int centerValue, in Side side, in CrossNeighbors<Neighbor<Square>> neighbors)
        {
            switch (side)
            {
                case Side.LEFT:
                    if (
                        neighbors.left.value > 0 &&
                        (HasNoNeighbor(centerValue, neighbors.left.value) == false
                         || HasNoNeighbor(centerValue, ~neighbors.left.value) == false)
                        )
                        return;
                    break;
                case Side.TOP:
                    if (
                        neighbors.top.value > 0 &&
                        (HasNoNeighbor(centerValue & 0b1100, (neighbors.top.value & 0b0011) << 2) == false
                        || HasNoNeighbor(centerValue & 0b1100, (~neighbors.top.value & 0b0011) << 2) == false)
                        )
                        return;
                    break;
                case Side.RIGHT:
                    if (
                        neighbors.right.value > 0 &&
                        (HasNoNeighbor(centerValue, neighbors.right.value) == false
                        || HasNoNeighbor(centerValue, ~neighbors.right.value) == false)
                        )
                        return;
                    break;
                case Side.BOTTOM:
                    if (
                        neighbors.bottom.value > 0 &&
                        (HasNoNeighbor(centerValue & 0b0011, (neighbors.bottom.value & 0b1100) >> 2) == false
                        || HasNoNeighbor(centerValue & 0b0011, (~neighbors.bottom.value & 0b1100) >> 2) == false)
                    )
                        return;
                    break;
            }

            MarchingSquareMeshHelper.DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, in value);
        }

        private static void DrawFace(ref int vertexIndex, ref int triangleIndex, int[] triangles, MeshVertexPool meshVertexPool, MeshSquare meshSquare, in int gridValue)
        {
            MarchingSquareMeshHelper.DrawFace(ref vertexIndex, ref triangleIndex, triangles, meshVertexPool, meshSquare, in gridValue);
        }
        private int GetAmountOfEdges(SquareVertex squareVertex, GridSquare grid)
        {
            var neighbors = grid.GetNeighbors(squareVertex);
            var edges = 0;
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i].value == 0)
                    edges++;
            }

            return edges;
        }

    }
}