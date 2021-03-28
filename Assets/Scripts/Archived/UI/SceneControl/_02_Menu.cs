namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class _02_Menu : MonoBehaviour
    {
        [Header("우측 판넬 설명/내용")]
        public Transform pnl_explain;
        public Transform pnl_content;

        [Header("레슨 선택 버튼")]
        public Button[] btn_lessons;

        [Header("pnl_content - 레슨 텍스트")]
        public Text txt_lesson;

        [Header("pnl_content - 내용 텍스트")]
        public Text[] txt_learningTargets;

        [Header("선택 완료 버튼")]
        public Button btn_select_completed;

        [Header("학습내용 세부선택 팝업")]
        public Transform pnl_select_destination;
        public Button btn_learning;
        public Button btn_experience;
        public Button btn_quiz;
        public Button btn_close_detailSelectPopup;

        private int selectedLessonIndex = -1;

        private void Awake()
        {
            Initialize();
            SetListeners();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            btn_select_completed.interactable = false;
        }

        private void SetListeners()
        {
            foreach (Button button in btn_lessons)
            {
                button.onClick.AddListener(() => { OnLessonButtonClicked(button.name); });
            }

            btn_select_completed.onClick.AddListener(() => { OnSelectCompletedButtonClicked(); });

            btn_learning.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName._03_Study_Youtube); });
            btn_experience.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName.GetLessonStringWithIndex(selectedLessonIndex), true); });
            btn_quiz.onClick.AddListener(() => { OnMoveSceneButtonClicked(SceneName._06_Quiz); });
            btn_close_detailSelectPopup.onClick.AddListener(() => { OnDetailSelectPopupCloseButtonClicked(); });
        }

        private void OnLessonButtonClicked(string buttonName)
        {
            if (selectedLessonIndex == -1) // if lesson is not selected
            {
                pnl_explain.gameObject.SetActive(false);
                pnl_content.gameObject.SetActive(true);
            }

            ActiveSelectCompletedButton();

            string[] array = buttonName.Split('_');
            selectedLessonIndex = int.Parse(array[array.Length - 1]) - 1;

            ShowLearningTargetData();
        }

        private void OnSelectCompletedButtonClicked()
        {
            pnl_select_destination.gameObject.SetActive(true);
        }

        private void ActiveSelectCompletedButton()
        {
            btn_select_completed.interactable = true;
        }

        private void OnMoveSceneButtonClicked(string sceneName, bool async = false)
        {
            Screen.FadeOut(() =>
            {
                PlayingData.selectedLessonIndex = selectedLessonIndex;

                if (async)
                    SceneLoader.LoadSceneAsync(sceneName);
                else
                    SceneLoader.LoadScene(sceneName);
            });
        }

        private void OnDetailSelectPopupCloseButtonClicked()
        {
            SetDetailSelectPopupActive(false);
        }

        private void ShowLearningTargetData()
        {
            DeactivateLearningTargetLists();

            // load csv data
            CSVLODataContainer container = CSVLODataContainer.GetOrCreateInstance();
            List<CSVLODataHolder> list = container.GetData(ELocation.Hotel, (EHotelLesson)selectedLessonIndex);

            string title = selectedLessonIndex == 0 ? "수상구조" : "심폐소생술";
            txt_lesson.text = title; //"Lesson 0" + (selectedLessonIndex + 1);
            for (int i = 0; i < list.Count; i++)
            {
                CSVLODataHolder holder = list[i];
                txt_learningTargets[i].gameObject.SetActive(true);
                txt_learningTargets[i].text = holder.lo;
            }
        }

        private void DeactivateLearningTargetLists()
        {
            foreach (Text text in txt_learningTargets)
            {
                text.gameObject.SetActive(false);
            }
        }

        private void SetDetailSelectPopupActive(bool active)
        {
            pnl_select_destination.gameObject.SetActive(active);
        }
    }
}