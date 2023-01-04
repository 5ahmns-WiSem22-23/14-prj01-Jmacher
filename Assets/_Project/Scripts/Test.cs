using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public ImageTest img;
}

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    private void OnEnable()
    {
        Test test = (Test)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Test test = (Test)target;
        if (GUILayout.Button("Assign")) test.img.color = test.GetComponent<Image>().color;
        if (GUILayout.Button("Print")) Debug.Log(test.img.color);

        serializedObject.ApplyModifiedProperties();
    }
}