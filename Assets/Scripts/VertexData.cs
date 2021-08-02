using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace MarchingSquare
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct VertexData : IEquatable<VertexData>
    {
        public static VertexAttributeDescriptor[] Layout { get; } = new[]{
            new VertexAttributeDescriptor(VertexAttribute.Position),
            new VertexAttributeDescriptor(VertexAttribute.Normal)
        };
        public readonly Vector3 position;
        public readonly Vector3 normal;
        public VertexData(Vector3 position, Vector3 normal)
        {
            this.position = position;
            this.normal = normal;
        }
        public override int GetHashCode() => (int)(position.x * 397 + position.y * 397 + position.z * 397);
        public bool Equals(VertexData other) => other.position.Equals(position);
    }
}