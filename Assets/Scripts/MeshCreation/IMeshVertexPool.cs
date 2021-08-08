using UnityEngine;

namespace MeshCreatorHelper
{
    public interface IMeshVertexPool<T>
    {
        int Add(T data);
        Vector3[] GetVertices();
        VertexBufferData GetVertexBufferData();
        void Clear();
    }
}