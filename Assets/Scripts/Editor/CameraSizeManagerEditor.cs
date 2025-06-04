using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraSizeManager))]
public class CameraSizeManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraSizeManager manager = (CameraSizeManager)target;

        if (GUILayout.Button("Adjust Scene Size"))
        {
            manager.AdjustSceneSize();
        }
    }
}
