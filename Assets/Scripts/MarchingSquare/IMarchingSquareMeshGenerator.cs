using UnityEngine;

namespace MarchingSquare
{
    public interface IMarchingSquareMeshGenerator
    {
        Mesh GenerateMesh(GridSquare grid, float offset);
    }
}