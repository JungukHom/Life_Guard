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

    public class LessonDisplayer : MonoBehaviour
    {
        public Text txt_lesson;
        public Text txt_korean;
        public Text txt_chinese;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            ShowDataHotel(PlayingData.selectedLessonIndex);
        }

        private void ShowDataHotel(int lesson)
        {
            // TODO : CSV 형태로 변경하기
            // 현재 개발 상 편의 문제로 CSV작업을 거치치 않고 진행. 추후 CSV파일 읽는 방식로 변경할 예정

            string korean = "";
            string chinese = "";

            switch (lesson)
            {
                case 0:
                    korean = "";
                    chinese = "수상안전관리";
                    break;

                case 1:
                    korean = "";
                    chinese = "심폐소생술";
                    break;
            }

            txt_lesson.text = "0" + (lesson + 1);
            txt_korean.text = korean;
            txt_chinese.text = chinese;
        }
    }
}
