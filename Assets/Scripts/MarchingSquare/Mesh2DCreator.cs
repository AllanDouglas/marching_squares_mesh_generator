#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MarchingSquare
{

    public class Mesh2DCreator : MonoBehaviour
    {
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float offset = 1;
        [SerializeField] private string meshName = "mesh";
        GridSquare gridSquare;

        [HideInInspector] [SerializeField] private List<int> vertices;
        private void LoadGrid()
        {
            gridSquare = new GridSquare(rows, columns);
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    gridSquare.SetVertexValue(new SquareVertex(x, y), GetVertexValue(x, y));
                }
            }

        }
        private int GetIndex(int x, int y) => (columns - 1) * y + x + y;
        private int GetVertexValue(int x, int y) => vertices[GetIndex(x, y)];
        private int SetVertexValue(int x, int y, int value) => vertices[GetIndex(x, y)] = value;
        private int ToggleVertexValue(int x, int y) =>
            vertices[GetIndex(x, y)] = vertices[GetIndex(x, y)] == 1 ? 0 : 1;



        private void Build()
        {
            string path = EditorUtility.SaveFilePanel("Save Separate Mesh Asset", "Assets/", meshName, "asset");
            if (string.IsNullOrEmpty(path)) return;

            LoadGrid();
            var mesh = new MarchingSquare2DMeshGenerator().GenerateMesh(gridSquare, offset);
            Physics.BakeMesh(mesh.GetInstanceID(), false);
            MeshUtility.Optimize(mesh);
            AssetDatabase.CreateAsset(mesh, FileUtil.GetProjectRelativePath(path));
            AssetDatabase.SaveAssets();

        }

        private void OnDrawGizmos()
        {
            LoadGrid();

            var matrix = Matrix4x4.Translate(transform.localPosition);

            DrawMesh(matrix);

        }

        private void DrawMesh(Matrix4x4 matrix)
        {
            var oldMatrix = Gizmos.matrix;
            Gizmos.matrix = matrix;
            Gizmos.color = Color.white;
            var mesh = new MarchingSquare2DMeshGenerator().GenerateMesh(gridSquare, offset);
            Gizmos.DrawMesh(mesh);
            Gizmos.matrix = oldMatrix;
        }


        [CustomEditor(typeof(Mesh2DCreator))]
        private class Mesh2DCreatorEditor : Editor
        {
            Mesh2DCreator mesh2DCreator;
            private bool dragging;
            private Vector3 startPosition;
            private Vector3 currentPosition;
            private Plane plane;

            private void OnEnable()
            {
                if (mesh2DCreator is null)
                {
                    Init();
                    plane = new Plane(Vector3.up, Vector3.zero);
                    SceneView.duringSceneGui += CustomOnSceneGUI;
                }

            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();


                if (GUILayout.Button("Update"))
                {
                    Init();
                }

                if (GUILayout.Button("Build"))
                {
                    mesh2DCreator.Build();
                }
            }

            private void CustomOnSceneGUI(SceneView obj)
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    startPosition = GetMousePosition();
                    dragging = true;
                }
                if (dragging && Event.current.type == EventType.MouseMove)
                {
                    currentPosition = GetMousePosition();

                    Select();
                }
                if (Event.current.type == EventType.MouseUp)
                {
                    dragging = false;
                }


                if (mesh2DCreator)
                    DrawButtons();
            }

            private Vector3 GetMousePosition()
            {
                var ray = Camera.current.ScreenPointToRay(Event.current.mousePosition);
                var pos = Vector3.zero;
                if (plane.Raycast(ray, out var distance))
                {
                    pos = ray.GetPoint(distance);
                }

                return pos;
            }

            private void Select()
            {
                var rect = new Rect(
                    startPosition.x,
                    startPosition.z,
                    startPosition.x - currentPosition.x,
                    startPosition.z - currentPosition.x);

                for (int x = 0; x < mesh2DCreator.columns; x++)
                {
                    for (int y = 0; y < mesh2DCreator.rows; y++)
                    {
                        var position = new Vector2(x * mesh2DCreator.offset, y * mesh2DCreator.offset);

                        if (rect.Contains(position))
                        {
                            mesh2DCreator.SetVertexValue(x, y, 1);
                        }

                    }
                }
            }

            private void Init()
            {

                mesh2DCreator = target as Mesh2DCreator;

                mesh2DCreator.vertices = new List<int>(
                    mesh2DCreator.columns * mesh2DCreator.rows
                );

                mesh2DCreator.vertices.Clear();

                for (int x = 0; x < mesh2DCreator.columns; x++)
                {
                    for (int y = 0; y < mesh2DCreator.rows; y++)
                    {
                        mesh2DCreator.vertices.Add(0);
                    }
                }
            }
            private void DrawButtons()
            {
                var oldMatrix = Handles.matrix;
                Handles.matrix = Matrix4x4.Translate(mesh2DCreator.transform.localPosition);
                for (int x = 0; x < mesh2DCreator.columns; x++)
                {
                    for (int y = 0; y < mesh2DCreator.rows; y++)
                    {
                        Handles.color = GetVertexValue(x, y) == 1 ? Color.black : Color.white;
                        var position = new Vector3(x * mesh2DCreator.offset, 0, y * mesh2DCreator.offset);
                        const float Size = .2f;
                        Handles.CubeHandleCap(
                            controlID: position.GetHashCode(),
                            position: position,
                            rotation: Quaternion.identity,
                            size: Size,
                            eventType: EventType.Repaint);

                        if (Handles.Button(
                            position,
                            Quaternion.AngleAxis(90, Vector3.right),
                            Size,
                            Size,
                            Handles.RectangleHandleCap
                        ))
                        {
                            ToggleVertexValue(x, y);
                        }

                    }
                }
                Handles.matrix = oldMatrix;
            }

            private int GetVertexValue(int x, int y) => mesh2DCreator.GetVertexValue(x, y);
            private int ToggleVertexValue(int x, int y) => mesh2DCreator.ToggleVertexValue(x, y);


        }

    }

}
#endif