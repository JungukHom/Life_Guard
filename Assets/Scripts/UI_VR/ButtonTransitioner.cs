namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using System;

    // Project
    // Alias

    public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public Color32 normalColor = Color.white;
        public Color32 hoverColor = Color.grey;
        public Color32 downColor = Color.white;

        private Image image = null;

        private void Awake()
        {
            image = GetComponent<Image>();

            try
            {
                if (IsLessonSelectButton(gameObject))
                {
                    image = transform.GetChild(0).GetComponent<Image>();
                }
            }
            catch { }

            gameObject.tag = "VRButton";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.color = hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.color = normalColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            image.color = downColor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // to nothing
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            image.color = hoverColor;

            GameObject pressedObject = eventData.pointerPressRaycast.gameObject;
            if (pressedObject && pressedObject.gameObject.CompareTag("VRButton"))
            {
                pressedObject.GetComponent<Button>().onClick.Invoke();
            }
        }

        private bool IsLessonSelectButton(GameObject gameObject)
        {
            return gameObject.name.Contains("btn_lesson_element");
        }
    }
}