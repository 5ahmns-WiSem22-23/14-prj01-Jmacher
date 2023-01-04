using UnityEngine;

[CreateAssetMenu(fileName = "New Button Setting", menuName = "Interface/Button Setting")]
public class ButtonSetting : ScriptableObject
{
    //Saved state data
    public StateData
        standart = new(),
        hover = new(),
        pressed = new();

    //Transition Settings
    public bool transition = true;
    public float
        standartToHoverDuration = .1f,
        hoverToStandartDuration = .1f,
        hoverToPressedDuration = .1f,
        pressedToHoverDuration = .1f;
    public AnimationCurve
        standartToHoverCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f),
        hoverToStandartCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f),
        hoverToPressedCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f),
        pressedToHoverCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    //Reference Count
    public int
        transformCount = 1,
        textCount = 1,
        imageCount = 1;

    //Inspector values
    public bool animationGroup = true, referenceGroup = true;
}