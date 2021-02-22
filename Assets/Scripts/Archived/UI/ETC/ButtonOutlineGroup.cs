namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class ButtonOutlineGroup : MonoBehaviour
    {
        public Button[] buttonGroup;

        [HideInInspector] public List<ButtonOutlineElement> outlineGroup;

        private void Start()
        {
            Initialize();
            SetListeners();
        }

        private void SetListeners()
        {
            foreach (Button button in buttonGroup)
            {
                button.onClick.AddListener(() =>
                {
                    DisableAllOutlines();
                    button.GetComponentInChildren<ButtonOutlineElement>().SetVisibillity(true);
                });
            }
        }

        private void Initialize()
        {
            outlineGroup = new List<ButtonOutlineElement>();
            foreach (Button button in buttonGroup)
            {
                outlineGroup.Add(button.GetComponentInChildren<ButtonOutlineElement>());
            }

            DisableAllOutlines();
        }

        public void DisableAllOutlines()
        {
            NotifyToAllOutline((outlineGroup) =>
            {
                outlineGroup.SetVisibillity(false);
            });
        }

        private void NotifyToAllOutline(Action<ButtonOutlineElement> action)
        {
            foreach (ButtonOutlineElement button in outlineGroup)
            {
                action?.Invoke(button);
            }
        }
    }
}
