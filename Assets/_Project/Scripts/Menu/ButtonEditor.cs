using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Button))]
public class ButtonEditor : Editor
{
    //Update state here
    public void Awake() => UpdateState((Button)target);

    public override void OnInspectorGUI()
    {
        Button bt = (Button)target;

        serializedObject.Update();

        bt.setting = (ButtonSetting)EditorGUILayout.ObjectField("Button Setting", bt.setting, typeof(ButtonSetting), false);

        if (bt.setting == null) return;

        bt.stateGroup = EditorGUILayout.BeginFoldoutHeaderGroup(bt.stateGroup, "States");
        if (bt.stateGroup)
        {
            //Load state here
            if (GUILayout.Button("Default"))
            {
                bt.stateSelected = State.Standart;
                if (bt.setting.standart.trs[0].IsEmpty) UpdateState(bt);
                else bt.SetState(bt.setting.standart);
            }
            if (GUILayout.Button("Hover"))
            {
                bt.stateSelected = State.Hover;
                if (bt.setting.hover.trs[0].IsEmpty) UpdateState(bt);
                else bt.SetState(bt.setting.hover);
            }
            if (GUILayout.Button("Pressed"))
            {
                bt.stateSelected = State.Pressed;
                if (bt.setting.hover.trs[0].IsEmpty) UpdateState(bt);
                else bt.SetState(bt.setting.hover);
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        GUILayout.BeginHorizontal();

        if (bt.setting.transition)
        {
            GUILayout.BeginVertical();

            bt.animationGroup = EditorGUILayout.BeginFoldoutHeaderGroup(bt.animationGroup, "Interpolation");
            if (bt.animationGroup)
            {
                GUILayout.BeginHorizontal();

                GUILayout.BeginVertical();
                EditorGUILayout.LabelField("Type", EditorStyles.boldLabel, GUILayout.MaxWidth(100));
                EditorGUILayout.LabelField("Default to Hover", GUILayout.MaxWidth(100));
                EditorGUILayout.LabelField("Hover to Pressed", GUILayout.MaxWidth(100));
                EditorGUILayout.LabelField("Hover to Default", GUILayout.MaxWidth(100));
                EditorGUILayout.LabelField("Pressed to Hover", GUILayout.MaxWidth(100));
                GUILayout.EndVertical();

                GUILayout.BeginVertical();
                EditorGUILayout.LabelField("Curve", EditorStyles.boldLabel);
                bt.setting.standartToHoverCurve = EditorGUILayout.CurveField(bt.setting.standartToHoverCurve);
                bt.setting.hoverToStandartCurve = EditorGUILayout.CurveField(bt.setting.hoverToStandartCurve);
                bt.setting.hoverToPressedCurve = EditorGUILayout.CurveField(bt.setting.hoverToPressedCurve);
                bt.setting.pressedToHoverCurve = EditorGUILayout.CurveField(bt.setting.pressedToHoverCurve);
                GUILayout.EndVertical();

                GUILayout.Space(10);

                GUILayout.BeginVertical();
                EditorGUILayout.LabelField("Duration", EditorStyles.boldLabel, GUILayout.MaxWidth(60));
                bt.setting.standartToHoverDuration = EditorGUILayout.DelayedFloatField(bt.setting.standartToHoverDuration, GUILayout.MaxWidth(60));
                bt.setting.hoverToStandartDuration = EditorGUILayout.DelayedFloatField(bt.setting.hoverToStandartDuration, GUILayout.MaxWidth(60));
                bt.setting.hoverToPressedDuration = EditorGUILayout.DelayedFloatField(bt.setting.hoverToPressedDuration, GUILayout.MaxWidth(60));
                bt.setting.pressedToHoverDuration = EditorGUILayout.DelayedFloatField(bt.setting.pressedToHoverDuration, GUILayout.MaxWidth(60));
                GUILayout.EndVertical();

                GUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            GUILayout.EndVertical();
        }
        else EditorGUILayout.LabelField("Interpolation");

        bt.setting.transition = EditorGUILayout.Toggle(bt.setting.transition, GUILayout.MaxWidth(20));

        GUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }

    public void UpdateState(Button bt)
    {
        UpdateReference(bt);

        switch (bt.stateSelected)
        {
            case State.Standart: bt.setting.standart = bt.GetState(); break;
            case State.Hover: bt.setting.hover = bt.GetState(); break;
            case State.Pressed: bt.setting.standart = bt.GetState(); break;
        }

        Debug.Log(bt.stateSelected + " updated!");
    }

    public void UpdateReference(Button bt)
    {
        bt.trsEnabled = bt.trs != null;
        bt.txtEnabled = bt.txt != null;
        bt.imgEnabled = bt.img != null;
    }

    //Todo
    //Implement Durations
    //Check if Cursor is inside or outside after click
    //Clean save & load
    //Disabled State?
    //Null Check
    //Make References and Scriptable Objects invisible

    //Done
    //Custom Button Setting Inspector
    //Save state Settings as scriptable Objects (1 Scriptable Object per Button)
    //OnClick Unity Event
    //Fix Coroutine
    //Set all array lengths to the length of the setting
}