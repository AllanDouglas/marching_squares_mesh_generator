using UnityEngine;
namespace MarchingSquare
{
    public struct MeshCube
    {
        private readonly Square square;
        private readonly float offset;

        public readonly MeshSquare FaceUp;
        public readonly MeshSquare FaceFront;
        public readonly MeshSquare FaceBack;
        public readonly MeshSquare FaceLeft;
        public readonly MeshSquare FaceRight;

        public MeshCube(Square square, float offset)
        {
            this.square = square;
            this.offset = offset;

            FaceUp = new MeshSquare(square: square, offset: offset);

            FaceFront = new MeshSquare(
                p1: FaceUp.P4,
                p2: FaceUp.P3,
                p3: new MeshVertex(FaceUp.P3.position + (Vector3.down * offset)),
                p4: new MeshVertex(FaceUp.P4.position + (Vector3.down * offset)),
                offset: offset
            );

            FaceBack = new MeshSquare(
                p1: FaceUp.P2,
                p2: FaceUp.P1,
                p3: new MeshVertex(FaceUp.P1.position + (Vector3.down * offset)),
                p4: new MeshVertex(FaceUp.P2.position + (Vector3.down * offset)),
                offset: offset
            );

            FaceLeft = new MeshSquare(
                p1: FaceUp.P1,
                p2: FaceUp.P4,
                p3: new MeshVertex(FaceUp.P4.position + (Vector3.down * offset)),
                p4: new MeshVertex(FaceUp.P1.position + (Vector3.down * offset)),
                offset
            );

            FaceRight = new MeshSquare(
                p1: FaceUp.P3,
                p2: FaceUp.P2,
                p3: new MeshVertex(FaceUp.P2.position + (Vector3.down * offset)),
                p4: new MeshVertex(FaceUp.P3.position + (Vector3.down * offset)),
                offset
            );

        }

    }

}