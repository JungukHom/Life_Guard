using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonThreeController_AirPort : GameController
{
    public GameObject passport;
    public GameObject pointBox;
    public GameObject ticket;
    public GameObject bag;
    public GameObject airplneTicket;
    public NPCController npcController;

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
                break;
            case 3:
                //여권, 티켓 NPC 한테 주기
                SetGrabObjectText("여권");
                passport.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 4:
                SetGrabObjectText("티켓");
                ticket.SetActive(true);
                passport.SetActive(false);
                break;
            case 5:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                ticket.SetActive(false);
                pointBox.SetActive(false);
                diaLogHolder.SoundOutput();
                break;

            case 6:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 7:
                SetGrabObjectText("가방");
                bag.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 8:
            case 9:
                diaLogHolder.SoundOutput();
                break;
            case 10:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                diaLogHolder.SoundOutput();
                break;
            case 11:
               SetEventObjectText("티켓");
                airplneTicket.SetActive(true);
                break;
            case 12:
                diaLogHolder.SoundOutput();
                break;

            default:
                EndAction();
                break;
        }
    }
}    
    
   
