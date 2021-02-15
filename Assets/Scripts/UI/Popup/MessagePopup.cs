namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    // Project
    // Alias

    public class MessagePopup : Popup
    {
        public Text txt_content;
        public Button btn_ok;
        public Button btn_cancel;

        private static readonly string PrefabPath = "Prefabs/Popups/MessagePopup";

        private Action okCallback;
        private Action cancelCallback;

        public static MessagePopup Show(string contentText, Action okCallback = null, Action cancelCallback = null)
        {
            GameObject prefab = Instantiate(Resources.Load(PrefabPath) as GameObject);
            MessagePopup component = prefab.GetComponent<MessagePopup>();
            component.SetData(contentText, okCallback, cancelCallback);

            return component;
        }

        protected new void Awake()
        {
            base.Awake();

            Initialize();
        }

        protected new void Initialize()
        {
            base.Initialize();

            SetSortingLayerToHighest();
            SetListeners();
        }

        protected new void SetListeners()
        {
            base.SetListeners();

            btn_ok.onClick.AddListener(() => OnOkButtonClicked());
            btn_cancel.onClick.AddListener(() => OnCancelButtonClicked());
        }

        private void SetData(string contentText, Action okCallback, Action cancelCallback)
        {
            this.okCallback = okCallback;
            this.cancelCallback = cancelCallback;

            txt_content.text = contentText;
        }

        private void OnOkButtonClicked()
        {
            okCallback?.Invoke();
            Destroy(transform.gameObject);
        }

        private void OnCancelButtonClicked()
        {
            cancelCallback?.Invoke();
            Destroy(transform.gameObject);
        }
    }
}
