using System;
using UnityEngine;

namespace MarchingSaquere
{
    public struct MeshVertex : IEquatable<MeshVertex>
    {
        public readonly Vector3 position;

        public MeshVertex(Vector3 position)
        {
            this.position = position;
        }

        public bool Equals(MeshVertex other) => position == other.position;

        public override int GetHashCode() => position.GetHashCode();

        public override string ToString() => position.ToString();
    }

}