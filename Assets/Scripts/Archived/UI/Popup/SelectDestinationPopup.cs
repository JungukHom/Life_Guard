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

    public class SelectDestinationPopup : Popup
    {
        [Header("추가 버튼")]
        public Button btn_learning;
        public Button btn_experience;
        public Button btn_quiz;

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

            btn_learning.onClick.AddListener(() => { OnLearningButtonClicked(); });
            btn_experience.onClick.AddListener(() => { OnExperienceButtonClicked(); });
            btn_quiz.onClick.AddListener(() => { OnQuizButtonClicked(); });
        }

        private void OnLearningButtonClicked()
        {
            SceneLoader.LoadScene(SceneName._03_Study_Youtube);
        }

        private void OnExperienceButtonClicked()
        {
            SceneLoader.LoadScene(SceneName.GetLessonStringWithIndex(PlayingData.selectedLessonIndex));
        }

        private void OnQuizButtonClicked()
        {
            SceneLoader.LoadScene(SceneName._06_Quiz);
        }
    }
}
