using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonFourController_AirPort : GameController
{
    public NPCController npcController;
    public GameObject bag;
    public GameObject bag_Up;
    public GameObject pointBox;
    public GameObject giftObject;

    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                FristAction();
                break;
            case 1:
                StartCoroutine("CheckButton");
                AddDialogIndex();
                break;
            case 2:
                diaLogHolder.SoundOutput();
                npcController.SetCharaterState(NPCController.CharaterState.Greet);
                break;
            case 3:
                diaLogHolder.SoundOutput();
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                break;
            case 4:
            case 5:
                diaLogHolder.SoundOutput();
                break;
            case 6:
                SetGrabObjectText("가방");
                bag.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 7:
                //가방 뒤지는 NPC
                bag_Up.SetActive(true);
                pointBox.SetActive(false);
                bag.SetActive(false);
                npcController.SetCharaterState(NPCController.CharaterState.Check);
                AddDialogIndex();
                break;
            case 8:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                giftObject.SetActive(true);
                diaLogHolder.SoundOutput();
                break;
			case 9:
                diaLogHolder.SoundOutput();
                break;
            case 10:
                diaLogHolder.SoundOutput();
                break;

            default:
                EndAction();
                break;
        }
    }
}    
    
   
