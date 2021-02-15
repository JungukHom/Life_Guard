using BusinessConversation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [Header("Panel")]
    public GameObject lessonChoosePanel;
    public GameObject RoomChoosePanel;
    public GameObject OptionSelectPanel;
    public GameObject OptionPanel;
   
    public GameObject[] lessonButtonsPanel;
    
    [Header("titleText")]
    public Text tileText;
    public Text tileText2;

    public Text[] lessonGoalTexts;

    int index = 0;
    CSVLODataContainer container;
    string title = "";

    private void Awake()
    {
        container = CSVLODataContainer.GetOrCreateInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePanel(OptionSelectPanel);
        }
    }

    public void RudderButtonClick()
    {
        index++;

        for (int i = 0; i < lessonButtonsPanel.Length; i++)
        {
            if (i == index % lessonButtonsPanel.Length)
            {
                lessonButtonsPanel[i].SetActive(true);
            }
            else
            {
                lessonButtonsPanel[i].SetActive(false);
            }
        }
    }

    public void LessonButtonClick(Button button)
    {
        string _index = button.GetComponentInChildren<Text>().text.Substring(0, 1);
        title = button.GetComponentInChildren<Text>().text;
        SetTitle(tileText, title);

        int index = int.Parse(_index);

        List<CSVLODataHolder> list = container.GetData(ELocation.Hotel, (EHotelLesson)index - 1);

        for (int i = 0; i < list.Count; i++)
        {
            lessonGoalTexts[i].text = list[i].lo;
        }
        if (list.Count == 2)
        {
            lessonGoalTexts[2].text = "";
        }
    }

    public void BackButtonClick()
    {
        ChangePanel(RoomChoosePanel);

        SetTitle(tileText2, title);
    }
    
    

    void SetTitle(Text text, string title)
    {
        text.text = title;
    }
    
    public void OptionButtonClick(Button button)
    {
        Debug.Log(button.name);
        switch (button.name)
        {
            case "Continue":
                OptionSelectPanel.SetActive(false);
                break;
            case "Option":
                ChangePanel(OptionSelectPanel.gameObject, OptionPanel);
                break;
            case "LessonChoose":
                SceneManager.LoadScene("UIScene");
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }



    void ChangePanel(GameObject nowPanel)
    {
        nowPanel.SetActive(!nowPanel.activeSelf);
    }

    void ChangePanel(GameObject nowPanel, GameObject nextPanel)
    {
        nowPanel.SetActive(!nowPanel.activeSelf);

        nextPanel.SetActive(!nextPanel.activeSelf);
    }

    public void SceneButton(Button button)
	{
        int index = int.Parse(button.GetComponentInChildren<Text>().text);

        SceneManager.LoadScene(index);
    }
}
