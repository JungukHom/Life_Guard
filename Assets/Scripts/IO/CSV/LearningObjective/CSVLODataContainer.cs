namespace BusinessConversation
{
    // C#
    using System.Collections.Generic;

    // static
    using static BusinessConversation.CSVLODataHeader;

    public class CSVLODataContainer : CSVDataContainer
    {
        private static CSVLODataContainer _instance = null;

        public static CSVLODataContainer GetOrCreateInstance() => _instance ?? (_instance = new CSVLODataContainer());

        private readonly List<CSVLODataHolder> holderList = new List<CSVLODataHolder>();

        private CSVLODataContainer()
        {
            List<Dictionary<string, object>> dataList = CSVReader.Read("Datas/db_learningObjective");

            foreach (Dictionary<string, object> data in dataList)
            {
                string _location = data[Location].ToString();
                string _lesson = data[Lesson].ToString();
                string _lo = data[LO].ToString();

                holderList.Add(new CSVLODataHolder(_location, _lesson, _lo));
            }
        }

        public List<CSVLODataHolder> GetData(ELocation location, EHotelLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        public List<CSVLODataHolder> GetData(ELocation location, EAirportLesson lesson)
        {
            string _location = GetStringLocation(location);
            string _lesson = GetStringLesson(lesson);

            return GetData(_location, _lesson);
        }

        private List<CSVLODataHolder> GetData(string location, string lesson)
        {
            List<CSVLODataHolder> tempList = new List<CSVLODataHolder>();

            foreach (CSVLODataHolder holder in holderList)
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
