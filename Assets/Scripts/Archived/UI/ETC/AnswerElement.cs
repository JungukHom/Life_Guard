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

    public class AnswerElement : MonoBehaviour
    {
        public Button btn_wrapperButton;
        public Text txt_answer;

        public AnswerPopup pnl_answerPopup;

        public Image img_ox;
        public Sprite sprite_o;
        public Sprite sprite_x;

        private AnswerDataOX answerDataOX;
        private AnswerDataMC answerDataMC;

        private int currentIndex = -1;

        //private void Start()
        //{
        //    Initialize();
        //}

        //private void Initialize()
        //{
        //    SetListeners();
        //}

        public void InitializeWith(AnswerDataOX data)
        {
            this.answerDataOX = data;
            currentIndex = data.number;

            SetAnswerText(data.playerAnswer);
            SetListeners();

            int intPlayerAnswer = data.playerAnswer == "O" ? 0 : 1;
            int intCorrectAnswer = data.correctAnswer == "O" ? 0 : 1;
            ChangeOXImage(intPlayerAnswer, intCorrectAnswer);
        }

        public void InitializeWith(AnswerDataMC data)
        {
            this.answerDataMC = data;
            currentIndex = data.number;

            SetAnswerText(data.playerAnswerString);
            SetListeners();
            ChangeOXImage(int.Parse(data.playerAnswer), int.Parse(data.correctAnswer));
        }

        private void SetListeners()
        {
            btn_wrapperButton.onClick.AddListener(() => { OnWrapperButtonClicked(); });
        }

        public void SetAnswerText(string playerAnswer)
        {
            txt_answer.text = playerAnswer;
        }

        private void OnWrapperButtonClicked()
        {
            bool isOX = currentIndex < 3;

            if (isOX)
                GetAnswerPopup().InitializeWith(answerDataOX);
            else
                GetAnswerPopup().InitializeWith(answerDataMC);
        }

        private AnswerPopup GetAnswerPopup()
        {
            return this.pnl_answerPopup;
        }

        private void ChangeOXImage(int playerAnswer, int correctAnswer)
        {
            if (playerAnswer == correctAnswer - 1)
            {
                img_ox.sprite = sprite_o;
            }
            else
            {
                img_ox.sprite = sprite_x;
            }
        }
    }
}
