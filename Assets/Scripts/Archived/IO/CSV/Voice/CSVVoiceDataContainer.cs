namespace BusinessConversation
{
    // C#
    using System.Collections.Generic;

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

            foreach (Dictionary<string, object> data in dataList)
            {
                string _location = data[Location].ToString();
                string _lesson = data[Lesson].ToString();
                string _type = data[Type].ToString();
                //string _index = data[Index].ToString();
                string _chinese = data[Chinese].ToString();
                string _pinyin = data[Pinyin].ToString();
                string _korean = data[Korean].ToString();
                string _filename = data[FileName].ToString();
                //string _extension = data[Extension].ToString();
                //string _remark = data[Remark].ToString();

                holderList.Add(new CSVVoiceDataHolder(_location, _lesson, _type, _chinese, _pinyin, _korean, _filename));
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
                    holder.lesson == lesson &&
                    holder.type == type)
                {
                    tempList.Add(holder);
                }
            }

            return tempList;
        }
    }
}