using UnityEngine;
namespace MarchingSquare
{
    public struct MeshSquare
    {
        private readonly Square square;
        private readonly float offset;
        public MeshSquare(Square square, float offset)
        {
            this.square = square;
            this.offset = offset;
        }

        public MeshVertex P1 => new MeshVertex(new Vector3(square.p1.x, 0, square.p1.y) * offset);
        public MeshVertex A => new MeshVertex(P1.position + Vector3.right * (offset * .5f));
        public MeshVertex P2 => new MeshVertex(new Vector3(square.p2.x, 0, square.p2.y) * offset);
        public MeshVertex B => new MeshVertex(P2.position + Vector3.back * (offset * .5f));
        public MeshVertex P3 => new MeshVertex(new Vector3(square.p3.x, 0, square.p3.y) * offset);
        public MeshVertex C => new MeshVertex(P3.position + Vector3.left * (offset * .5f));
        public MeshVertex P4 => new MeshVertex(new Vector3(square.p4.x, 0, square.p4.y) * offset);
        public MeshVertex D => new MeshVertex(P4.position + Vector3.forward * (offset * .5f));

    }

}