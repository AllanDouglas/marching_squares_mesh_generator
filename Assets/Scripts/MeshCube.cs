using System;
using UnityEngine;

namespace MarchingSquare
{
    public readonly struct MeshCube
    {
        public static int AmountOfFaces = 5;
        private readonly float offset;
        public readonly MeshSquare Up;
        public MeshSquare Front => new MeshSquare(
                p1: Up.P4,
                p2: Up.P3,
                p3: new MeshVertex(Up.P3.position + (Vector3.down * offset)),
                p4: new MeshVertex(Up.P4.position + (Vector3.down * offset)),
                offset: offset
            );
        public MeshSquare Back => new MeshSquare(
                p1: Up.P2,
                p2: Up.P1,
                p3: new MeshVertex(Up.P1.position + (Vector3.down * offset)),
                p4: new MeshVertex(Up.P2.position + (Vector3.down * offset)),
                offset: offset
            );
        public MeshSquare Left => new MeshSquare(
                p1: Up.P1,
                p2: Up.P4,
                p3: new MeshVertex(Up.P4.position + (Vector3.down * offset)),
                p4: new MeshVertex(Up.P1.position + (Vector3.down * offset)),
                offset
            );
        public MeshSquare Right => new MeshSquare(
                p1: Up.P3,
                p2: Up.P2,
                p3: new MeshVertex(Up.P2.position + (Vector3.down * offset)),
                p4: new MeshVertex(Up.P3.position + (Vector3.down * offset)),
                offset
            );

        public MeshCube(Square square, float offset)
        {
            this.offset = offset;
            Up = new MeshSquare(square: square, offset: offset);
        }

        public MeshSquare this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Up;
                    case 1: return Front;
                    case 2: return Right;
                    case 3: return Left;
                    case 4: return Back;
                    default: throw new IndexOutOfRangeException();
                }

            }
        }

    }

}