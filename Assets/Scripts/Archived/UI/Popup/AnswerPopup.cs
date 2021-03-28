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

    public class AnswerPopup : Popup
    {
        public Text txt_number;
        public Text txt_question;
        public Text txt_explain;
        public Text txt_commentary;

        public Transform pnl_ox;

        public Button btn_play;

        public Transform pnl_mc;
        public Text txt_choice_01;
        public Text txt_choice_02;
        public Text txt_choice_03;
        public Text txt_choice_04;

        public Image[] img_ox_array;
        public Image[] img_mc_array;

        private List<CSVQuizOXDataHolder> listOX;

        private bool isOX = true;

        protected new void Awake()
        {
            SetListeners();

            listOX = CSVQuizOXDataContainer.GetOrCreateInstance().GetData(ELocation.Hotel,
                        (EHotelLesson)PlayingData.selectedLessonIndex);
        }

        protected new void SetListeners()
        {
            //base.SetListeners();
            btn_close.onClick.AddListener(() => OnCloseButtonClicked());
            btn_backgroundPannel.onClick.AddListener(() => OnBackgroundButtonClicked());
        }

        protected new void OnCloseButtonClicked()
        {
            Close();
        }

        protected new void OnBackgroundButtonClicked()
        {
            if (unhandledAreaSwitcher)
            {
                Close();
            }
        }


        public void Show()
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }

        public void Close()
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -5000);
        }

        public void InitializeWith(AnswerDataOX data)
        {
            Show();

            isOX = true;
            DisableAllOutlines();

            string number = "0" + (data.number + 1);
            if (data.number == 9)
            {
                number = "10";
            }

            txt_number.text = number;
            txt_question.text = data.question;
            txt_explain.text = data.explain;
            txt_commentary.text = data.commentary;

            pnl_ox.gameObject.SetActive(true);
            pnl_mc.gameObject.SetActive(false);

            int playerAnswerIndex = data.playerAnswer == "O" ? 0 : 1;
            EnableOutline(playerAnswerIndex);

            int answer = data.correctAnswer == "O" ? 0 : 1;
            btn_play.onClick.AddListener(() => { OnPlayButtonClicked(answer); });
        }
        public void InitializeWith(AnswerDataMC data)
        {
            Show();

            isOX = false;
            DisableAllOutlines();

            string number = "0" + (data.number + 1);
            if (data.number == 9)
            {
                number = "10";
            }

            txt_number.text = number;
            txt_question.text = data.question;
            txt_explain.text = data.explain;
            txt_commentary.text = data.commentary;

            txt_choice_01.text = data.choice_01;
            txt_choice_02.text = data.choice_02;
            txt_choice_03.text = data.choice_03;
            txt_choice_04.text = data.choice_04;

            pnl_ox.gameObject.SetActive(false);
            pnl_mc.gameObject.SetActive(true);

            EnableOutline(int.Parse(data.correctAnswer));
        }

        private void EnableOutline(int index)
        {
            try
            {
                Image target = isOX ? img_ox_array[index] : img_mc_array[index];
                Color color = target.color;
                color.a = 1;
                target.color = color;
            } catch { }
        }

        private void DisableAllOutlines()
        {
            foreach (Image element in img_ox_array)
            {
                Color color = element.color;
                color.a = 0;
                element.color = color;
            }

            foreach (Image element in img_mc_array)
            {
                Color color = element.color;
                color.a = 0;
                element.color = color;
            }
        }

        private void OnPlayButtonClicked(int answerIndex)
        {
            AudioClip clip = Resources.Load(listOX[answerIndex].GetVoiceFilePath()) as AudioClip;
            Sound.GetOrCreate().PlayVoiceSound(clip);
        }
    }
}
