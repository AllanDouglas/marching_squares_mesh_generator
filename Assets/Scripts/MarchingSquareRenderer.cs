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
        [Range(1, 15)]
        [SerializeField] private int testValue = 1;
        [SerializeField] private string binaryRepresentation;

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
            var matrix = Matrix4x4.Translate(Vector3.zero);
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

        [ExecuteInEditMode]
        private void OnValidate()
        {
            binaryRepresentation = System.Convert.ToString(testValue, 2);
        }

        private void OnDrawGizmos()
        {
            gridSquare = new GridSquare(3, 3);

            var numbers = new[] { 1, 1, 0, 1, 0, 0, 0, 0, 0 };
            var index = 0;
            for (int y = 0; y < gridSquare.rows; y++)
            {
                for (int x = 0; x < gridSquare.columns; x++)
                {
                    gridSquare.SetVertexValue(new SquareVertex(x, y), numbers[index]);
                    index++;
                }
            }

            // gridSquare.SetVertexValue(new SquareVertex(0, 1), ((testValue & 0b1000) >> 3) == 1 ? 1 : 0); // 1
            // gridSquare.SetVertexValue(new SquareVertex(1, 1), ((testValue & 0b0100) >> 2) == 1 ? 1 : 0); // 2
            // gridSquare.SetVertexValue(new SquareVertex(1, 0), ((testValue & 0b0010) >> 1) == 1 ? 1 : 0); // 3
            // gridSquare.SetVertexValue(new SquareVertex(0, 0), (testValue & 0b0001) == 1 ? 1 : 0);        // 4

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