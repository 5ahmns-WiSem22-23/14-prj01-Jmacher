using UnityEngine;

public class StateData
{
    public RectTransformSetting[] trs = new RectTransformSetting[1];
    public TextSetting[] txt = new TextSetting[1];
    public Color[] img = new Color[1];
}

public struct RectTransformSetting
{
    public Vector2
        anchoredPosition,
        anchorMax,
        anchorMin,
        offsetMax,
        offsetMin,
        pivot,
        sizeDelta;
    public Vector3 anchoredPosition3D;

    public static RectTransformSetting Lerp(RectTransformSetting a, RectTransformSetting b, float t) => new()
    {
        anchoredPosition = Vector2.Lerp(a.anchoredPosition, b.anchoredPosition, t),
        anchoredPosition3D = Vector3.Lerp(a.anchoredPosition3D, b.anchoredPosition3D, t),
        anchorMax = Vector2.Lerp(a.anchorMax, b.anchorMax, t),
        anchorMin = Vector2.Lerp(a.anchorMin, b.anchorMin, t),
        offsetMax = Vector2.Lerp(a.offsetMax, b.offsetMax, t),
        offsetMin = Vector2.Lerp(a.offsetMin, b.offsetMin, t),
        pivot = Vector2.Lerp(a.pivot, b.pivot, t),
        sizeDelta = Vector2.Lerp(a.sizeDelta, b.sizeDelta, t)
    };
}

public struct TextSetting
{
    public float fontSize;
    public Color color;

    public static TextSetting Lerp(TextSetting a, TextSetting b, float t) => new()
    {
        fontSize = Mathf.Lerp(a.fontSize, b.fontSize, t),
        color = Color.Lerp(a.color, b.color, t)
    };
}