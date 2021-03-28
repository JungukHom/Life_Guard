namespace BusinessConversation
{
    // C#
    using System;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // static
    using static BusinessConversation.CSVVoiceDataHeader;

    public class CSVVoiceDataContainer : CSVDataContainer
    {
        private static CSVVoiceDataContainer _instance = null;

        public static CSVVoiceDataContainer GetOrCreateInstance() => _instance ?? (_instance = new CSVVoiceDataContainer());

        private readonly List<CSVVoiceDataHolder> holderList = new List<CSVVoiceDataHolder>();

        private CSVVoiceDataContainer()
        {
            List<Dictionary<string, object>> dataList = CSVReader.Read("Datas/db_voice");

            //Debug.Log($"key count : {dataList[0].Keys.Count}");

            string debug = "";
            try
            {
                foreach (Dictionary<string, object> data in dataList)
                {
                    debug = "";
                    string _location = data[Location].ToString();
                    debug += _location;

                    string _lesson = data[Lesson].ToString();
                    debug += _lesson;

                    string _type = data[CSVVoiceDataHeader.Type].ToString();
                    debug += _type;

                    //string _index = data[Index].ToString();
                    string _chinese = data[Chinese].ToString();
                    debug += _chinese;

                    string _pinyin = data[Pinyin].ToString();
                    debug += _pinyin;

                    string _korean = data[Korean].ToString();
                    debug += _korean;

                    string _filename = data[FileName].ToString();
                    debug += _filename;
                    //string _extension = data[Extension].ToString();
                    //string _remark = data[Remark].ToString();

                    holderList.Add(new CSVVoiceDataHolder(_location, _lesson, _type, _chinese, _pinyin, _korean, _filename));
                }
            }
            catch
            {
                Debug.Log($"debug : {debug}");
            }
        }

        public List<CSVVoiceDataHolder> GetData(ELocation location, EHotelLesson lesson, EVoiceType type)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);
            string _type = GetStringType(type);

            return GetData(_location, _lesson, _type);
        }

        public List<CSVVoiceDataHolder> GetData(ELocation location, EAirportLesson lesson, EVoiceType type)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);
            string _type = GetStringType(type);

            return GetData(_location, _lesson, _type);
        }

        private List<CSVVoiceDataHolder> GetData(string location, string lesson, string type)
        {
            List<CSVVoiceDataHolder> tempList = new List<CSVVoiceDataHolder>();

            foreach (CSVVoiceDataHolder holder in holderList)
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