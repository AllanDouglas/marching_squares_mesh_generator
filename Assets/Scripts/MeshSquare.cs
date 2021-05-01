using UnityEngine;
namespace MarchingSaquere
{
    public struct MeshSquare
    {
        private readonly Square square;
        private readonly float offset;
        private readonly Matrix4x4 matrix;

        public MeshSquare(Square square, float offset, Matrix4x4 matrix)
        {
            this.square = square;
            this.offset = offset;
            this.matrix = matrix;
        }

        public MeshVertex P1 => new MeshVertex(matrix.MultiplyPoint3x4(new Vector3(square.p1.x, 0, square.p1.y) * offset));
        public MeshVertex A => new MeshVertex(matrix.MultiplyPoint3x4(P1.position + Vector3.right * (offset * .5f)));
        public MeshVertex P2 => new MeshVertex(matrix.MultiplyPoint3x4(new Vector3(square.p2.x, 0, square.p2.y) * offset));
        public MeshVertex B => new MeshVertex(matrix.MultiplyPoint3x4(P2.position + Vector3.back * (offset * .5f)));
        public MeshVertex P3 => new MeshVertex(matrix.MultiplyPoint3x4(new Vector3(square.p3.x, 0, square.p3.y) * offset));
        public MeshVertex C => new MeshVertex(matrix.MultiplyPoint3x4(P3.position + Vector3.left * (offset * .5f)));
        public MeshVertex P4 => new MeshVertex(matrix.MultiplyPoint3x4(new Vector3(square.p4.x, 0, square.p4.y) * offset));
        public MeshVertex D => new MeshVertex(matrix.MultiplyPoint3x4(P4.position + Vector3.forward * (offset * .5f)));

    }

}