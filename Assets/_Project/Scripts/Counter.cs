using UnityEngine;
using UnityEngine.UIElements;

public class Counter : MonoBehaviour
{
    private TextElement count;

    private void OnEnable() => count = GetComponent<UIDocument>().rootVisualElement.Q<TextElement>("count");
}