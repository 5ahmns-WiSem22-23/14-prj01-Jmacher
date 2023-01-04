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
    public bool trsEnabled = true, txtEnabled = true, imgEnabled = true, isClicking;

    //References
    public RectTransform[] trs;
    public TextMeshProUGUI[] txt;
    public Image[] img;

    //Inspector values
    public bool stateGroup, animationGroup;

    private void Awake() => SetState(setting.standart);

    public void OnPointerEnter(PointerEventData eventData) => Switch(setting.hover);
    public void OnPointerExit(PointerEventData eventData) => Switch(setting.standart);
    public void OnPointerDown(PointerEventData eventData) => Switch(setting.pressed);

    private void Switch(StateData target)
    {
        if (isClicking) return;

        if (transition != null) StopCoroutine(transition);

        //Handle special Click event
        if (target == setting.pressed)
        {
            isClicking = true;
            transition = Transition(target, /*setting.duration / 2*/ .05f, true);
        }
        else transition = Transition(target, /*setting.duration*/ .1f, false);

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
            trs = trsEnabled ? new RectTransformSetting[setting.transformCount] : null,
            txt = txtEnabled ? new TextSetting[setting.textCount] : null,
            img = imgEnabled ? new ImageSetting[setting.imageCount] : null
        };

        while (time < duration)
        {
            //Calculate lerp factor
            float fac = Mathf.InverseLerp(0, duration, time);

            //Populate current values
            if (trsEnabled) for (int i = 0; i < setting.transformCount; i++) current.trs[i] = RectTransformSetting.Lerp(start.trs[i], target.trs[i], fac);
            if (txtEnabled) for (int i = 0; i < setting.textCount; i++) current.txt[i] = TextSetting.Lerp(start.txt[i], target.txt[i], fac);
            if (imgEnabled) for (int i = 0; i < setting.imageCount; i++) current.img[i] = ImageSetting.Lerp(start.img[i], target.img[i], fac);

            //Set current state
            SetState(current);

            //Update time as last step
            time += Time.deltaTime;

            yield return null;
        }

        //Mirror if needed
        if (mirror)
        {
            onClick.Invoke();

            //Set transition target depening on if the cursor is within rect
            transition = gameObject.GetComponent<RectTransform>().rect.Contains(Input.mousePosition)
                ? Transition(setting.hover, duration, false)
                : Transition(setting.standart, duration, false);

            //Stop ignoring mouse events
            isClicking = false;

            StartCoroutine(transition);
        }
    }
    public StateData GetState()
    {
        //Create settings
        RectTransformSetting[] trsState = trsEnabled ? new RectTransformSetting[setting.transformCount] : null;
        TextSetting[] txtState = txtEnabled ? new TextSetting[setting.textCount] : null;
        ImageSetting[] imgState = imgEnabled ? new ImageSetting[setting.imageCount] : null;

        //Assign settings if enabled
        if (trsEnabled)
        {
            for (int i = 0; i < setting.transformCount; i++)
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
        }
        if (txtEnabled)
        {
            for (int i = 0; i < setting.textCount; i++)
            {
                txtState[i].font = txt[i].font;
                txtState[i].fontSize = txt[i].fontSize;
                txtState[i].color = txt[i].color;
            }
        }
        if (imgEnabled)
        {
            for (int i = 0; i < setting.imageCount; i++)
            {
                imgState[i].sprite = img[i].sprite;
                imgState[i].color = img[i].color;
            }
        }

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
        if (trsEnabled)
        {
            for (int i = 0; i < setting.transformCount; i++)
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
        }
        if (txtEnabled)
        {
            for (int i = 0; i < setting.textCount; i++)
            {
                txt[i].font = state.txt[i].font;
                txt[i].fontSize = state.txt[i].fontSize;
                txt[i].color = state.txt[i].color;
            }
        }
        if (imgEnabled)
        {
            for (int i = 0; i < setting.imageCount; i++)
            {
                img[i].sprite = state.img[i].sprite;
                img[i].color = state.img[i].color;
            }
        }
    }
}

public enum State
{
    Standart,
    Hover,
    Pressed
}