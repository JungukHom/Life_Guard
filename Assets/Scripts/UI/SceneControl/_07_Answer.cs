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

    public class _07_Answer : MonoBehaviour
    {
        public Button exitButton;

        public AnswerElement[] answerElements;

        private List<CSVQuizOXDataHolder> holderOX = null;
        private List<CSVQuizMCDataHolder> holderMC = null;

        private void Awake()
        {
            Initialize();
            SetListeners();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            LoadAnswerData();
            RegisterAnswerData();
        }

        private void SetListeners()
        {
            exitButton.onClick.AddListener(() => { OnExitButtonClicked(); });
        }

        private void LoadAnswerData()
        {
            if (PlayingData.isHotel)
            {
                holderOX = CSVQuizOXDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
                holderMC = CSVQuizMCDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
            }
            else
            {
                holderOX = CSVQuizOXDataContainer.GetOrCreateInstance().GetData(ELocation.Airport, (EAirportLesson)PlayingData.selectedLessonIndex);
                holderMC = CSVQuizMCDataContainer.GetOrCreateInstance().GetData(ELocation.Airport, (EAirportLesson)PlayingData.selectedLessonIndex);
            }
            
        }

        private void RegisterAnswerData()
        {
            QuizChoiceData quizPlayData = QuizChoiceData.GetOrCreate();

            for (int i = 0; i < 10; i++)
            {
                if (i <= 2)
                {
                    answerElements[i].InitializeWith(new AnswerDataOX()
                    {
                        number = i,
                        question = holderOX[i].question,
                        explain = holderOX[i].explain,
                        playerAnswer = quizPlayData.GetChoice(i) == 0 ? "O" : "X",
                        correctAnswer = holderOX[i].answer,
                        commentary = holderOX[i].commentary
                    });
                }
                else if (i >= 3 && i < 10)
                {
                    answerElements[i].InitializeWith(new AnswerDataMC()
                    {
                        number = i,
                        question = holderMC[i - 3].question,
                        explain = holderMC[i - 3].explain,
                        choice_01 = holderMC[i - 3].choice_01,
                        choice_02 = holderMC[i - 3].choice_02,
                        choice_03 = holderMC[i - 3].choice_03,
                        choice_04 = holderMC[i - 3].choice_04,
                        playerAnswer = quizPlayData.GetChoice(i).ToString(),
                        playerAnswerString = holderMC[i - 3].GetChoiceStringWithIndex(quizPlayData.GetChoice(i)),
                        correctAnswer = holderMC[i - 3].answer,
                        commentary = holderMC[i - 3].commentary
                    });
                }
                else
                {
                    // do nothing
                }
            }
        }

        private void OnExitButtonClicked()
        {
            Screen.FadeOut(() =>
            {
                SceneLoader.LoadScene(SceneName._02_Menu_Hotel);
            });
        }
    }
}
