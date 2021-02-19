using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonFourController_AirPort_VR : GameController
{
    public NPCController npcController;
    public GameObject bag;
    public GameObject bag_Up;
    public GameObject pointBox;
    public TeleportVive teleportVive;
    public GameObject giftObjects;

    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                teleportVive.enabled = false;
                AddDialogIndex();
                SetVRFirstText();
                Action();
                break;
            case 1:
                StartCoroutine("CheckVRButton");
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
                giftObjects.SetActive(true);
                diaLogHolder.SoundOutput();
                break;
            case 9:
                diaLogHolder.SoundOutput();
                break;

            case 10:
                diaLogHolder.SoundOutput();
                break;

            default:
                teleportVive.enabled = true;
                EndVRAction();
                break;
        }
    }

    
}    
    
   
