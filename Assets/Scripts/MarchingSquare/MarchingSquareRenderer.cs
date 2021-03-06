using UnityEngine;
using Random = UnityEngine.Random;

namespace MarchingSquare
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
        private IMarchingSquareMeshGenerator meshGenerator;
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;

        private void Awake()
        {
            meshGenerator = new MarchingSquare3DMeshGenerator();
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
                        gridSquare.SetVertexValue(new SquareVertex(x, y), 1);
                        continue;
                    }

                    gridSquare.SetVertexValue(new SquareVertex(x, y), Random.value > .5f ? 1 : 0);
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
            meshFilter.mesh = meshGenerator.GenerateMesh(gridSquare, offset);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReloadGrid();
                LoadMesh();
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Random.InitState(seed.GetHashCode());
            LoadGrid();

            var matrix = Matrix4x4.Translate(transform.localPosition);

            DrawMesh(matrix);
            DrawPoints(matrix);
        }

        private void DrawMesh(Matrix4x4 matrix)
        {
            var oldMatrix = Gizmos.matrix;
            Gizmos.matrix = matrix;
            Gizmos.color = Color.white;
            var mesh = new MarchingSquare3DMeshGenerator().GenerateMesh(gridSquare, offset);
            Gizmos.DrawMesh(mesh);
            Gizmos.matrix = oldMatrix;
        }

        private void DrawPoints(Matrix4x4 matrix)
        {
            var oldMatrix = Gizmos.matrix;
            Gizmos.matrix = matrix;
            for (int x = 0; x < gridSquare.columns; x++)
            {
                for (int y = 0; y < gridSquare.rows; y++)
                {
                    Gizmos.color = gridSquare.GetVertexValue(x, y) == 1 ? Color.black : Color.white;
                    Gizmos.DrawCube(new Vector3(x * offset, 0, y * offset), Vector3.one * .2f);

                }
            }
            Gizmos.matrix = oldMatrix;
        }
#endif

    }

}