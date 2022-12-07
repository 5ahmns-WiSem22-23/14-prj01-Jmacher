using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleManager))]
public class ObstacleManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var om = target as ObstacleManager;
        if (GUILayout.Button("Generate")) om.Spawn();
    }
}