using UnityEngine;

namespace MarchingSquare
{
    public interface IMarchingSaquereMeshGenerator
    {
        Mesh GenerateMesh(GridSquare grid, float offset);
    }
}