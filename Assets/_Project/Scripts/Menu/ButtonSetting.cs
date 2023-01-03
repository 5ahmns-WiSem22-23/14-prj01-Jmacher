using UnityEngine;

[CreateAssetMenu(fileName = "New Button Setting", menuName = "Interface/Button Setting")]
public class ButtonSetting : ScriptableObject
{
    //State Settings
    public StateData
        standart = new(),
        hover = new(),
        pressed = new();

    //Transition
    public float duration = .1f;
}