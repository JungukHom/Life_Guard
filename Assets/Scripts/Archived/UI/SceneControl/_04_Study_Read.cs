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

    public class _04_Study_Read : MonoBehaviour
    {
        public Button btn_play;

        public Text txt_chinese;
        public Text txt_pinyin;
        public Text txt_korean;

        public Button btn_previous;
        public Button btn_next;

        private int currentIndex = 0;

        private List<CSVVoiceDataHolder> voiceDataList;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            SetListeners();

            LoadVoiceData();
            InvalidateTextData();
        }

        private void SetListeners()
        {
            btn_previous.onClick.AddListener(() => { OnMoveButtonClicked(false); });
            btn_next.onClick.AddListener(() => { OnMoveButtonClicked(true); });
        }

        private void OnMoveButtonClicked(bool isNext)
        {
            if (isNext && currentIndex == voiceDataList.Count - 1)
            {
                MessagePopup.Show("체험방으로 이동합니다.", () =>
                {
                    SceneLoader.LoadSceneAsync(SceneName.GetLessonStringWithIndex(PlayingData.selectedLessonIndex));
                },
                () =>
                {
                    // do nothing
                    // = null
                });

                return;
            }

            currentIndex += isNext ? 1 : -1;
            currentIndex = Mathf.Clamp(currentIndex, 0, voiceDataList.Count - 1);
            InvalidateTextData();
        }

        private void LoadVoiceData()
        {
            CSVVoiceDataContainer container = CSVVoiceDataContainer.GetOrCreateInstance();

            CustomList<CSVVoiceDataHolder> wordList;
            CustomList<CSVVoiceDataHolder> sentenceList;

            wordList = CustomList<CSVVoiceDataHolder>.Create(container.GetData(ELocation.Hotel,
                    (EHotelLesson)PlayingData.selectedLessonIndex, EVoiceType.Word));
            sentenceList = CustomList<CSVVoiceDataHolder>.Create(container.GetData(ELocation.Hotel,
                (EHotelLesson)PlayingData.selectedLessonIndex, EVoiceType.Conversation));

            voiceDataList = wordList + sentenceList;
        }

        private void InvalidateTextData()
        {
            txt_chinese.text = voiceDataList[currentIndex].chinese;
            txt_pinyin.text = voiceDataList[currentIndex].pinyin;
            txt_korean.text = voiceDataList[currentIndex].korean;
        }
    }
}
