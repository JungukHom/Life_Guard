namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    using static BusinessConversation.CHN.Hotel.CSVQuizMCDataHeader;

    public class CSVQuizMCDataContainer : CSVDataContainer
    {
        private static CSVQuizMCDataContainer _instance = null;

        public static CSVQuizMCDataContainer GetOrCreateInstance() => _instance ?? (_instance = new CSVQuizMCDataContainer());

        private readonly List<CSVQuizMCDataHolder> holderList = new List<CSVQuizMCDataHolder>();

        private CSVQuizMCDataContainer()
        {
            List<Dictionary<string, object>> dataList = CSVReader.Read("Datas/db_quiz_mc");

            for (int i = 0; i < 98; i++)
            {
                try
                {
                    Dictionary<string, object> data = dataList[i];

                    string _location = data[Location].ToString();
                    string _lesson = data[Lesson].ToString();
                    string _index = data[Index].ToString();

                    string _question = data[Question].ToString();
                    string _explain = data[Explain].ToString();

                    string _choice_01 = data[Choice_01].ToString();
                    string _choice_02 = data[Choice_02].ToString();
                    string _choice_03 = data[Choice_03].ToString();
                    string _choice_04 = data[Choice_04].ToString();

                    string _answer = data[Answer].ToString();
                    string _commentary = data[Commentary].ToString();

                    holderList.Add(new CSVQuizMCDataHolder(_location, _lesson, _index,
                                                            _question, _explain,
                                                            _choice_01, _choice_02, _choice_03, _choice_04,
                                                            _answer, _commentary));
                }
                catch
                {
                    break;
                }
            }
        }

        public List<CSVQuizMCDataHolder> GetData(ELocation location, EHotelLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        public List<CSVQuizMCDataHolder> GetData(ELocation location, EAirportLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        private List<CSVQuizMCDataHolder> GetData(string location, string lesson)
        {
            List<CSVQuizMCDataHolder> tempList = new List<CSVQuizMCDataHolder>();

            foreach (CSVQuizMCDataHolder holder in holderList)
            {
                if (holder.location == location &&
                    holder.lesson == lesson)
                {
                    tempList.Add(holder);
                }
            }

            return tempList;
        }
    }
}
