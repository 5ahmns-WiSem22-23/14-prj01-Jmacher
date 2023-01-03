using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI Tools/Button")]
public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public ButtonSetting setting;
    public UnityEvent onClick;
    public State stateSelected;
    private IEnumerator transition;

    //References
    public RectTransform[] trs;
    public TextMeshProUGUI[] txt;
    public Image[] img;

    private void Awake() => SetState(setting.standart);

    public void OnPointerEnter(PointerEventData eventData) => Switch(setting.hover);
    public void OnPointerExit(PointerEventData eventData) => Switch(setting.standart);
    public void OnPointerDown(PointerEventData eventData) => Switch(setting.pressed);

    private void Switch(StateData target)
    {
        if (transition != null) StopCoroutine(transition);

        //If target state is pressed state transition should mirror
        transition = target == setting.pressed ? Transition(target, setting.duration / 2, true) : Transition(target, setting.duration, false);

        StartCoroutine(transition);
    }
    private IEnumerator Transition(StateData target, float duration, bool mirror)
    {
        float time = 0;

        //Get current state as start state
        StateData start = GetState();

        //Create empty transition state
        StateData current = new()
        {
            trs = new RectTransformSetting[start.trs.Length],
            txt = new TextSetting[start.txt.Length],
            img = new Color[start.img.Length]
        };

        while (time < duration)
        {
            //Calculate lerp factor
            float fac = Mathf.InverseLerp(0, duration, time);

            //Populate current values
            for (int i = 0; i < trs.Length; i++) current.trs[i] = RectTransformSetting.Lerp(start.trs[i], target.trs[i], fac);
            for (int i = 0; i < txt.Length; i++) current.txt[i] = TextSetting.Lerp(start.txt[i], target.txt[i], fac);
            for (int i = 0; i < img.Length; i++) current.img[i] = Color.Lerp(start.img[i], target.img[i], fac);

            //Set current state
            SetState(current);

            //Update time as last step
            time += Time.deltaTime;

            yield return null;
        }

        //Recursion if needed
        if (mirror)
        {
            onClick.Invoke();
            transition = Transition(start, duration, false);
            StartCoroutine(transition);
        }
    }
    public StateData GetState()
    {
        //Create settings
        RectTransformSetting[] trsState = new RectTransformSetting[trs.Length];
        TextSetting[] txtState = new TextSetting[txt.Length];
        Color[] imgState = new Color[img.Length];

        //Assign settings
        for (int i = 0; i < trs.Length; i++)
        {
            trsState[i].anchoredPosition = trs[i].anchoredPosition;
            trsState[i].anchoredPosition3D = trs[i].anchoredPosition3D;
            trsState[i].anchorMax = trs[i].anchorMax;
            trsState[i].anchorMin = trs[i].anchorMin;
            trsState[i].offsetMax = trs[i].offsetMax;
            trsState[i].offsetMin = trs[i].offsetMin;
            trsState[i].pivot = trs[i].pivot;
            trsState[i].sizeDelta = trs[i].sizeDelta;
        }
        for (int i = 0; i < txt.Length; i++)
        {
            txtState[i].fontSize = txt[i].fontSize;
            txtState[i].color = txt[i].color;
        }
        for (int i = 0; i < img.Length; i++) imgState[i] = img[i].color;

        //Return finished state
        return new StateData()
        {
            trs = trsState,
            txt = txtState,
            img = imgState
        };
    }
    public void SetState(StateData state)
    {
        for (int i = 0; i < trs.Length; i++)
        {
            trs[i].anchoredPosition = state.trs[i].anchoredPosition;
            trs[i].anchoredPosition3D = state.trs[i].anchoredPosition3D;
            trs[i].anchorMax = state.trs[i].anchorMax;
            trs[i].anchorMin = state.trs[i].anchorMin;
            trs[i].offsetMax = state.trs[i].offsetMax;
            trs[i].offsetMin = state.trs[i].offsetMin;
            trs[i].pivot = state.trs[i].pivot;
            trs[i].sizeDelta = state.trs[i].sizeDelta;
        }
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].fontSize = state.txt[i].fontSize;
            txt[i].color = state.txt[i].color;
        }
        for (int i = 0; i < img.Length; i++) img[i].color = state.img[i];
    }
}

public enum State
{
    Standart,
    Hover,
    Pressed
}