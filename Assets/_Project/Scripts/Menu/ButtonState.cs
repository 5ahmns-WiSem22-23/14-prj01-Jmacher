using TMPro;
using UnityEngine;

public class StateData
{
    public RectTransformSetting[] trs = new RectTransformSetting[1];
    public TextSetting[] txt = new TextSetting[1];
    public ImageSetting[] img = new ImageSetting[1];
}

public struct RectTransformSetting
{
    public Vector2 anchoredPosition, anchorMax, anchorMin, offsetMax, offsetMin, pivot, sizeDelta;
    public Vector3 anchoredPosition3D;

    public bool IsEmpty => Check();
    private bool Check() =>
        anchoredPosition == Vector2.zero
        && anchorMax == Vector2.zero
        && anchorMin == Vector2.zero
        && offsetMax == Vector2.zero
        && offsetMin == Vector2.zero
        && pivot == Vector2.zero
        && sizeDelta == Vector2.zero
        && anchoredPosition3D == Vector3.zero;
    public static RectTransformSetting Default() => new()
    {
        anchoredPosition = Vector2.zero,
        anchoredPosition3D = Vector3.zero,
        anchorMax = new(.5f, .5f),
        anchorMin = new(.5f, .5f),
        offsetMax = new(50, 50),
        offsetMin = new(-50, -50),
        pivot = new(.5f, .5f),
        sizeDelta = new(100, 100)
    };
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
    public TMP_FontAsset font;
    public float fontSize;
    public Color color;

    public bool IsEmpty => Check();
    private bool Check() =>
        font == null
        && fontSize == 0
        && color == Color.clear;
    public static TextSetting Default() => new()
    {
        font = null,
        fontSize = 35,
        color = Color.black
    };
    public static TextSetting Lerp(TextSetting a, TextSetting b, float t) => new()
    {
        font = t < .5f ? a.font : b.font,
        fontSize = Mathf.Lerp(a.fontSize, b.fontSize, t),
        color = Color.Lerp(a.color, b.color, t)
    };
}

public struct ImageSetting
{
    public Sprite sprite;
    public Color color;

    public bool IsEmpty => Check();
    private bool Check() =>
        sprite == null
        && color == Color.clear;
    public static ImageSetting Default() => new()
    {
        sprite = null,
        color = Color.magenta
    };
    public static ImageSetting Lerp(ImageSetting a, ImageSetting b, float t) => new()
    {
        sprite = t < .5f ? a.sprite : b.sprite,
        color = Color.Lerp(a.color, b.color, t)
    };
}