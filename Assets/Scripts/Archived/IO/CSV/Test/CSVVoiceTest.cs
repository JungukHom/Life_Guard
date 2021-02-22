namespace BusinessConversation
{
    // C#
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    public class CSVVoiceTest : MonoBehaviour
    {
        private CSVVoiceDataContainer container = null;
        private List<CSVVoiceDataHolder> list = null;

        private AudioSource source = null;

        private void Awake()
        {
            source = gameObject.AddComponent<AudioSource>();
        }

        private void Start()
        {
            container = CSVVoiceDataContainer.GetOrCreateInstance();
            list = container.GetData(ELocation.Hotel, EHotelLesson._01, EVoiceType.Conversation);

            foreach (CSVVoiceDataHolder data in list)
            {
                Debug.Log($"CN : {data.chinese}, KR : {data.korean}, filePath : {data.GetVoiceFilePath()}");
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                string voiceFilePath = list[0].GetVoiceFilePath();
                Debug.Log($"Voice file path : {voiceFilePath}");
                AudioClip clip = Resources.Load(voiceFilePath) as AudioClip;
                source.PlayOneShot(clip);
            }
        }
    }
}
