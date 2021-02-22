namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    // Project
    // Alias

    public class ESCPopup : Popup
    {
        public Button btn_continue;
        public Button btn_settings;
        public Button btn_lesson_select;
        public Button btn_quit;

        protected new void Awake()
        {
            base.Awake();
            Initialize();
        }

        protected new void Initialize()
        {
            base.Initialize();
        }

        protected new void SetListeners()
        {
            base.SetListeners();

            btn_continue.onClick.AddListener(() => OnContinueButtonClicked());
            btn_settings.onClick.AddListener(() => OnSettingsButtonClicked());
            btn_lesson_select.onClick.AddListener(() => OnLessonSelectButtonClicked());
            btn_quit.onClick.AddListener(() => OnQuitButtonClicked());
        }

        private void OnContinueButtonClicked()
        {
            OnCloseButtonClicked();
        }

        private void OnSettingsButtonClicked()
        {
            // TODO : SettingsPopup 생성
        }

        private void OnLessonSelectButtonClicked()
        {
            // TODO : MessagePopup 생성
            // 확인 : 02.Menu 씬으로 이동
            // 취소 : 취소
        }

        private void OnQuitButtonClicked()
        {
            // TODO : MessagePopup 생성
            // 확인 : 프로그램 종료
            // 취소 : 취소
        }
    }
}
