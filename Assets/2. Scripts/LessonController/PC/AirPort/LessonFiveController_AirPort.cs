using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonFiveController_AirPort : GameController
{
    public NPCController npcController;
    public GameObject textUI;
    public GameObject dutyFree;
    private void Start()
    {
        textUI.SetActive(false);
    }

    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                StartCoroutine("CheckButton");
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                AddDialogIndex();
                textUI.SetActive(true);
                SetFirstText();
                break;
            case 1:
                diaLogHolder.SoundOutput();
                npcController.SetCharaterState(NPCController.CharaterState.Greet);
                dutyFree.SetActive(true);
                break;
            case 2:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                diaLogHolder.SoundOutput();
                break;
            case 7:
                StopCoroutine("CheckButton");
                dutyFree.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1f, 1f, 2f);
                GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = true;
                EndAction();
                break;

            default:
                this.enabled = false;
                break;
        }
    }
}    
    
   
