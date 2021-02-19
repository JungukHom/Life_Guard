using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BusinessConversation;
using TMPro;

public class DiaLogHolder : MonoBehaviour
{
    private CSVVoiceDataContainer container = null;
    private List<CSVVoiceDataHolder> list = null;
    private AudioSource source = null;
    
    TextMeshProUGUI DiaLogText;
    public ELocation eLocation;
    public EHotelLesson eHotelLesson;

    GameController gameController;
    bool soundOff = true;
    int index = 0;
    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        container = CSVVoiceDataContainer.GetOrCreateInstance();
        list = container.GetData(eLocation, eHotelLesson, EVoiceType.Conversation);
        DiaLogText = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
    }
    
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void SoundOutput()
    {
        if (index < list.Count && soundOff)
        {
            string voiceFilePath = list[index].GetVoiceFilePath();
            AudioClip clip = Resources.Load(voiceFilePath) as AudioClip;
          
            source.PlayOneShot(clip);

            float waitSecnod = clip.length;
            DiaLogText.text = list[index].korean;
            
            soundOff = false;
            StartCoroutine(WaitForSecond(waitSecnod));
            
            index++;
        }
    }

    public void Replay()
	{
        if (index < list.Count + 1 && soundOff && index != 0)
        {
            index--;

            string voiceFilePath = list[index].GetVoiceFilePath();
            AudioClip clip = Resources.Load(voiceFilePath) as AudioClip;

            source.PlayOneShot(clip);

            float waitSecnod = clip.length;
            DiaLogText.text = list[index].korean;

            soundOff = false;
            StartCoroutine(WaitForSecond(waitSecnod));

            index++;
        }
    }
   
    IEnumerator WaitForSecond(float secnod)
    {
        yield return new WaitForSeconds(secnod);
        soundOff = true;
        gameController.AddDialogIndex();
    }
}
