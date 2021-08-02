using System;
using UnityEngine;

namespace MarchingSquare
{
    public readonly struct MeshVertex : IEquatable<MeshVertex>
    {
        public readonly Vector3 position;
        private readonly int hashCode;

        public MeshVertex(Vector3 position)
        {
            this.position = position;

            unchecked
            {
                hashCode = (int)(position.x * 397 + position.y * 397 + position.z * 397);
            }
        }

        public bool Equals(MeshVertex other) => position == other.position;

        public override int GetHashCode() => hashCode;

        public override string ToString() => position.ToString();
    }

}