using MeshCreatorHelper;
using UnityEngine;
namespace MarchingSquare
{
    public struct MeshSquare
    {

        private readonly float offset;
        public readonly MeshVertex P1;
        public readonly MeshVertex P2;
        public readonly MeshVertex P3;
        public readonly MeshVertex P4;

        public MeshSquare(Square square, float offset)
        {
            this.offset = offset;
            P1 = new MeshVertex(new Vector3(square.p1.x, 0, square.p1.y) * offset);
            P2 = new MeshVertex(new Vector3(square.p2.x, 0, square.p2.y) * offset);
            P3 = new MeshVertex(new Vector3(square.p3.x, 0, square.p3.y) * offset);
            P4 = new MeshVertex(new Vector3(square.p4.x, 0, square.p4.y) * offset);
        }

        public MeshSquare(MeshVertex p1, MeshVertex p2, MeshVertex p3, MeshVertex p4, float offset)
        {
            this.offset = offset;
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public MeshVertex A => new MeshVertex(P1.position + Dir(in P2, in P1) * (offset * .5f));
        public MeshVertex B => new MeshVertex(P2.position + Dir(in P3, in P2) * (offset * .5f));
        public MeshVertex C => new MeshVertex(P3.position + Dir(in P4, in P3) * (offset * .5f));
        public MeshVertex D => new MeshVertex(P4.position + Dir(in P1, in P4) * (offset * .5f));
        private Vector3 Dir(in MeshVertex from, in MeshVertex to) => (from.position - to.position).normalized;

    }

}