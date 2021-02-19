namespace BusinessConversation
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    public class CSVLOTest : MonoBehaviour
    {
        private void Start()
        {
            CSVLODataContainer container = CSVLODataContainer.GetOrCreateInstance();
            List<CSVLODataHolder> list = container.GetData(ELocation.Hotel, EHotelLesson._01);
            
            foreach (CSVLODataHolder data in list)
            {
                Debug.Log($"MAJOR : {data.location}, LESSON : {data.lesson}, LO : {data.lo}");
            }

            List<CSVLODataHolder> list2 = container.GetData(ELocation.Hotel, EHotelLesson._03);
            foreach (CSVLODataHolder data in list2)
            {
                Debug.Log($"MAJOR : {data.location}, LESSON : {data.lesson}, LO : {data.lo}");
            }
        }
    }
}
