using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ButtonSetting))]
public class ButtonSettingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ButtonSetting bs = (ButtonSetting)target;

        serializedObject.Update();

        GUILayout.BeginHorizontal();

        if (bs.transition)
        {
            GUILayout.BeginVertical();

            bs.animationGroup = EditorGUILayout.BeginFoldoutHeaderGroup(bs.animationGroup, "Interpolation");
            if (bs.animationGroup)
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
                bs.standartToHoverCurve = EditorGUILayout.CurveField(bs.standartToHoverCurve);
                bs.hoverToStandartCurve = EditorGUILayout.CurveField(bs.hoverToStandartCurve);
                bs.hoverToPressedCurve = EditorGUILayout.CurveField(bs.hoverToPressedCurve);
                bs.pressedToHoverCurve = EditorGUILayout.CurveField(bs.pressedToHoverCurve);
                GUILayout.EndVertical();

                GUILayout.Space(10);

                GUILayout.BeginVertical();
                EditorGUILayout.LabelField("Duration", EditorStyles.boldLabel, GUILayout.MaxWidth(60));
                bs.standartToHoverDuration = EditorGUILayout.DelayedFloatField(bs.standartToHoverDuration, GUILayout.MaxWidth(60));
                bs.hoverToStandartDuration = EditorGUILayout.DelayedFloatField(bs.hoverToStandartDuration, GUILayout.MaxWidth(60));
                bs.hoverToPressedDuration = EditorGUILayout.DelayedFloatField(bs.hoverToPressedDuration, GUILayout.MaxWidth(60));
                bs.pressedToHoverDuration = EditorGUILayout.DelayedFloatField(bs.pressedToHoverDuration, GUILayout.MaxWidth(60));
                GUILayout.EndVertical();

                GUILayout.EndHorizontal();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            GUILayout.EndVertical();
        }
        else EditorGUILayout.LabelField("Interpolation");

        bs.transition = EditorGUILayout.Toggle(bs.transition, GUILayout.MaxWidth(20));

        GUILayout.EndHorizontal();

        bs.referenceGroup = EditorGUILayout.BeginFoldoutHeaderGroup(bs.referenceGroup, "Required References");
        if (bs.referenceGroup)
        {
            bs.transformCount = EditorGUILayout.IntSlider("Transform Components", bs.transformCount, 0, 5);
            bs.textCount = EditorGUILayout.IntSlider("Text Components", bs.textCount, 0, 5);
            bs.imageCount = EditorGUILayout.IntSlider("Image Components", bs.imageCount, 0, 5);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}