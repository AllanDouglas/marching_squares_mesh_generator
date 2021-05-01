using UnityEngine;
using Random = UnityEngine.Random;

namespace MarchingSaquere
{

    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class MarchingSquareRenderer : MonoBehaviour
    {
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float offset = 1;

        [SerializeField] private string seed;

        GridSquare gridSquare;
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();

            Random.InitState(seed.GetHashCode());

            LoadGrid();
        }

        private void LoadGrid()
        {
            gridSquare = new GridSquare(rows, columns);
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {

                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        gridSquare.SetVeterxValue(new SquareVertex(x, y), 1);
                        continue;
                    }

                    gridSquare.SetVeterxValue(new SquareVertex(x, y), Random.value > .5f ? 1 : 0);
                }
            }
        }

        private void ReloadGrid()
        {
            Random.InitState((int)Time.time);
            LoadGrid();
        }

        private void Start()
        {
            LoadMesh();

        }

        private void LoadMesh()
        {
            var matrix = Matrix4x4.Translate(transform.position);
            meshFilter.mesh = MarchingSquareMeshGenerator.GenerateMesh(gridSquare, matrix, offset);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReloadGrid();
                LoadMesh();
            }
        }

    }

}