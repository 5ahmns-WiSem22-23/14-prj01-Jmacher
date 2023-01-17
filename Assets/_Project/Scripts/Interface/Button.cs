using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Interface
{
    public enum ButtonState
    {
        Default,
        Hover,
        Pressed,
        Disabled
    }

    public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SerializeField] private UnityEvent onClick;

        [Header("Settings")]
        [SerializeField] private float duration = .2f;
        [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private Vector2[] buttonSize = new Vector2[4];
        [SerializeField] private float[] fontSize = new float[4];
        [SerializeField] private Color[] fontColor = new Color[4];
        [SerializeField] private Color[] imageColor = new Color[4];

        [Header("References")]
        [SerializeField] private RectTransform transformComponent;
        [SerializeField] private TextMeshProUGUI textComponent;
        [SerializeField] private Image imageComponent;

        public bool Active
        {
            get => buttonState == ButtonState.Disabled;
            set
            {
                if (Active && buttonState != ButtonState.Default) Switch(ButtonState.Default);
                else if (!Active && buttonState != ButtonState.Disabled) Switch(ButtonState.Disabled);
            }
        }

        private ButtonState buttonState;
        private IEnumerator transition;

        private void OnEnable() => SetState(ButtonState.Default);

        public void OnPointerEnter(PointerEventData eventData) => Switch(ButtonState.Hover);
        public void OnPointerExit(PointerEventData eventData) => Switch(ButtonState.Default);
        public void OnPointerDown(PointerEventData eventData) => Switch(ButtonState.Pressed);

        private void Switch(ButtonState target)
        {
            if (buttonState == ButtonState.Pressed) return;
            if (buttonState == target) return;

            if (transition != null) StopCoroutine(transition);
            transition = Transition(target);
            StartCoroutine(transition);
        }
        private IEnumerator Transition(ButtonState target)
        {
            ButtonState start = buttonState;

            Vector2 startButtonSize = transformComponent.sizeDelta;
            float startFontSize = textComponent.fontSize;
            Color startFontColor = textComponent.color;
            Color startImageColor = imageComponent.color;

            buttonState = target;

            float limit = duration;
            if (target == ButtonState.Pressed || start == ButtonState.Pressed) limit = duration / 2;

            float time = 0;

            while (time < limit)
            {
                float fac = Mathf.InverseLerp(0, duration, time);
                float smooth = curve.Evaluate(fac);

                transformComponent.sizeDelta = Vector2.Lerp(startButtonSize, buttonSize[(int)target], smooth);
                textComponent.fontSize = Mathf.Lerp(startFontSize, fontSize[(int)target], smooth);
                textComponent.color = Color.Lerp(startFontColor, fontColor[(int)target], smooth);
                imageComponent.color = Color.Lerp(startImageColor, imageColor[(int)target], smooth);

                time += Time.deltaTime;

                yield return null;
            }

            SetState(target);

            if (target == ButtonState.Pressed)
            {
                buttonState = ButtonState.Default;
                onClick.Invoke();

                if (!gameObject.activeInHierarchy) yield break;

                transition = Transition(ButtonState.Hover);
                StartCoroutine(transition);
            }
        }
        private void SetState(ButtonState target)
        {
            transformComponent.sizeDelta = buttonSize[(int)target];
            textComponent.fontSize = fontSize[(int)target];
            textComponent.color = fontColor[(int)target];
            imageComponent.color = imageColor[(int)target];
        }
    }
}