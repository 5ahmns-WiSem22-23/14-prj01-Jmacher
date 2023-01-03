using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Button))]
public class ButtonEditor : Editor
{
    private SerializedProperty trs, txt, img, setting, onClick;

    public void OnEnable()
    {
        trs = serializedObject.FindProperty("trs");
        txt = serializedObject.FindProperty("txt");
        img = serializedObject.FindProperty("img");
        setting = serializedObject.FindProperty("setting");
        onClick = serializedObject.FindProperty("onClick");
    }

    public override void OnInspectorGUI()
    {
        Button btn = (Button)target;

        EditorGUILayout.PropertyField(setting);
        EditorGUILayout.PropertyField(onClick);

        GUILayout.BeginHorizontal();
        btn.stateSelected = (State)EditorGUILayout.EnumPopup(btn.stateSelected);
        if (GUILayout.Button("Save"))
        {
            switch (btn.stateSelected)
            {
                case State.Standart: btn.setting.standart = btn.GetState(); break;
                case State.Hover: btn.setting.hover = btn.GetState(); break;
                case State.Pressed: btn.setting.pressed = btn.GetState(); break;
            }

            EditorUtility.SetDirty(btn.setting);
            AssetDatabase.SaveAssets();
        }
        if (GUILayout.Button("Load"))
        {
            AssetDatabase.Refresh();

            switch (btn.stateSelected)
            {
                case State.Standart: btn.SetState(btn.setting.standart); break;
                case State.Hover: btn.SetState(btn.setting.hover); break;
                case State.Pressed: btn.SetState(btn.setting.pressed); break;
            }
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.PropertyField(trs, new GUIContent("RectTransform Components"));
        EditorGUILayout.PropertyField(txt, new GUIContent("TextMeshPro Components"));
        EditorGUILayout.PropertyField(img, new GUIContent("Image Components"));

        serializedObject.ApplyModifiedProperties();
    }

    //Todo
    //Custom Button Setting Inspector
    //Clean save & load
    //Create individual transition durations and animation curves
    //Disabled State?

    //Done
    //Save state Settings as scriptable Objects (1 Scriptable Object per Button)
    //OnClick Unity Event
    //Fix Coroutine
}