namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    public class SceneName
    {
        public static readonly string _00_Splash = "00.Splash";
        public static readonly string _01_Title = "01.Title";
        public static readonly string _02_Menu = "02.Menu";

        public static readonly string _03_Study_Youtube = "03.Study_Youtube";
        public static readonly string _04_Study_Read = "04.Study_Read";

        public static readonly string _05_Lesson_01 = "05.Lesson_01";
        public static readonly string _05_Lesson_02 = "05.Lesson_02";

        public static readonly string _06_Quiz = "06.Quiz";
        public static readonly string _07_Answer = "07.Answer";
        public static readonly string _99_Loading = "99.Loading";

        public static string GetLessonStringWithIndex(int index)
        {
            if (index < 0 || index > 2)
            {
                index = 0;
            }

            index += 1;
            return "05.Lesson_0" + index;
        }
    }
}
