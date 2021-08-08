using System;
using UnityEngine;

namespace MeshCreatorHelper
{
    public readonly struct MeshVertex : IEquatable<MeshVertex>
    {
        public readonly Vector3 position;
        public readonly Color color;
        public readonly Vector3 normal;

        public MeshVertex(Vector3 position,
            Color color = default, Vector3 normal = default)
        {
            this.position = position;
            this.color = color;
            this.normal = normal;
        }

        public MeshVertex(Vector3 position)
        {
            this.position = position;
            color = Color.white;
            normal = Vector3.up;
        }

        public bool Equals(MeshVertex other) => position == other.position;

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)(position.x * 397 + position.y * 397 + position.z * 397);
            }
        }

        public override string ToString() => position.ToString();
    }

}