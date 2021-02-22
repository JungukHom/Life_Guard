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
        public static readonly string _02_Menu_Hotel = "02.Menu_Hotel";
        public static readonly string _02_Menu_Airport = "02.Menu_Airport";
        public static readonly string _03_Study_Youtube = "03.Study_Youtube";
        public static readonly string _04_Study_Read = "04.Study_Read";

        public static readonly string _05_Lesson_01 = "05.Lesson_01";
        public static readonly string _05_Lesson_02 = "05.Lesson_02";
        public static readonly string _05_Lesson_03 = "05.Lesson_03";
        public static readonly string _05_Lesson_04 = "05.Lesson_04";
        public static readonly string _05_Lesson_05 = "05.Lesson_05";
        public static readonly string _05_Lesson_06 = "05.Lesson_06";
        public static readonly string _05_Lesson_07 = "05.Lesson_07";
        public static readonly string _05_Lesson_08 = "05.Lesson_08";

        public static readonly string _06_Quiz = "06.Quiz";
        public static readonly string _07_Answer = "07.Answer";

        public static readonly string _99_Loading = "99.Loading";

        public static string GetLessonStringWithIndex(int index)
        {
            if (index < 0 || index > 7)
            {
                index = 0;
            }

            index += 1;
            return "05.Lesson_0" + index;
        }
    }
}
