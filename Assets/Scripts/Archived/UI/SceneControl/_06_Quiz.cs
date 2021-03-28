namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class _06_Quiz : MonoBehaviour
    {
        [Header("Common")]
        public Text txt_question;
        public Text txt_explain;
        public Button btn_previous;
        public Button btn_next;

        [Header("O/X Pannel")]
        public Transform pnl_content_ox;
        public Button btn_play;
        public ButtonOutlineGroup oxGroup;
        public Button btn_o;
        public Button btn_x;

        [Header("Multiple Choice Pannel")]
        public Transform pnl_content_mc;
        public ButtonOutlineGroup mcGroup;
        public Button btn_choice_01;
        public Button btn_choice_02;
        public Button btn_choice_03;
        public Button btn_choice_04;


        [SerializeField] private int currentIndex = 0;

        private List<CSVQuizOXDataHolder> listOX;
        private List<CSVQuizMCDataHolder> listMC;


        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetListeners();

            Screen.NotifySceneLoaded();
            CursorControl.VisibleMode();

            LoadQuizData();
            InvalidateWithOXData();
        }

        private void SetListeners()
        {
            // content common
            btn_previous.onClick.AddListener(() => OnMoveButtonClicked(false));
            btn_next.onClick.AddListener(() => OnMoveButtonClicked(true));

            // content ox
            btn_play.onClick.AddListener(() => OnReplayButtonClicked());
            btn_o.onClick.AddListener(() => OnOXButtonClicked(true));
            btn_x.onClick.AddListener(() => OnOXButtonClicked(false));

            // content multiple choice
            btn_choice_01.onClick.AddListener(() => OnChoiceButtonClicked(0));
            btn_choice_02.onClick.AddListener(() => OnChoiceButtonClicked(1));
            btn_choice_03.onClick.AddListener(() => OnChoiceButtonClicked(2));
            btn_choice_04.onClick.AddListener(() => OnChoiceButtonClicked(3));
        }

        private void OnMoveButtonClicked(bool isNext)
        {
            if (isNext && !CheckCurrentOutlineSelected())
            {
                MessagePopup.Show("답안을 선택해주세요");
                return;
            }

            if (isNext && currentIndex == listOX.Count + listMC.Count - 1)
            {
                MessagePopup.Show("퀴즈가 종료되었습니다.\n채점하시겠습니까?", () =>
                {
                    SceneLoader.LoadScene(SceneName._07_Answer);
                },
                () =>
                {
                    // do nothing
                });

                return;
            }

            currentIndex += isNext ? 1 : -1;
            currentIndex = Mathf.Clamp(currentIndex, 0, 10);

            oxGroup.DisableAllOutlines();
            mcGroup.DisableAllOutlines();

            if (currentIndex >= 0 && currentIndex <= listOX.Count - 1)
            {
                InvalidateWithOXData();
            }
            else if (currentIndex >= listOX.Count && currentIndex <= listOX.Count + listMC.Count - 1)
            {
                InvalidateWithMCData();
            }
            else
            {
                // do nothing
            }
        }

        private void OnReplayButtonClicked()
        {
            PlayOXVoice();
        }

        private void OnOXButtonClicked(bool value)
        {
            QuizChoiceData data = QuizChoiceData.GetOrCreate();
            data.EditChoice(currentIndex, (value ? 0 : 1));
        }
        private void OnChoiceButtonClicked(int answer)
        {
            QuizChoiceData data = QuizChoiceData.GetOrCreate();
            data.EditChoice(currentIndex, answer);
        }

        private void LoadQuizData()
        {
            listOX = CSVQuizOXDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
            listMC = CSVQuizMCDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel, (EHotelLesson)PlayingData.selectedLessonIndex);
        }

        private void InvalidateWithOXData()
        {
            try
            {
                QuizChoiceData data = QuizChoiceData.GetOrCreate();
                if (data.HasChoice(currentIndex))
                {
                    int existingAnswer = data.GetChoice(currentIndex);
                    oxGroup.outlineGroup[existingAnswer].SetVisibillity(true);
                }

                ToggleOXorMCUI(true);

                txt_question.text = listOX[currentIndex].question;
                txt_explain.text = listOX[currentIndex].explain;
            }
            catch (System.Exception e)
            {
                Debug.Log($"{e.Message}\n{e.StackTrace}");
            }
        }

        private void InvalidateWithMCData()
        {
            QuizChoiceData data = QuizChoiceData.GetOrCreate();
            if (data.HasChoice(currentIndex))
            {
                int existingAnswer = data.GetChoice(currentIndex);
                mcGroup.outlineGroup[existingAnswer].SetVisibillity(true);
            }

            ToggleOXorMCUI(false);

            CSVQuizMCDataHolder holder = listMC[currentIndex - listOX.Count];
            txt_question.text = holder.question;
            txt_explain.text = holder.explain;
            btn_choice_01.GetComponentInChildren<Text>().text = holder.choice_01;
            btn_choice_02.GetComponentInChildren<Text>().text = holder.choice_02;
            btn_choice_03.GetComponentInChildren<Text>().text = holder.choice_03;
            btn_choice_04.GetComponentInChildren<Text>().text = holder.choice_04;

            StopOXVoice();
        }

        private void ToggleOXorMCUI(bool isOX)
        {
            pnl_content_ox.gameObject.SetActive(isOX);
            pnl_content_mc.gameObject.SetActive(!isOX);
        }

        private void PlayOXVoice()
        {
            AudioClip clip = Resources.Load(listOX[currentIndex].GetVoiceFilePath()) as AudioClip;
            Sound.GetOrCreate().PlayVoiceSound(clip);
        }

        private void StopOXVoice()
        {
            Sound.GetOrCreate().StopVoiceSound();
        }

        private bool CheckCurrentOutlineSelected()
        {
            return QuizChoiceData.GetOrCreate().HasChoice(currentIndex);
        }
    }
}
