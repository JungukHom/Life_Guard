using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonSixController_VR : GameController
{
    public NPCController npcController;
    public TeleportVive teleportVive;
    public GameObject roomKey;
    public GameObject pointBox;
    public GameObject card;

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
            case 3:
            case 4:
                diaLogHolder.SoundOutput();
                break;
            case 5:
                //방키 주기
                SetGrabObjectText("방키");
                roomKey.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 6:
                roomKey.SetActive(false);
                pointBox.SetActive(false);
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                AddDialogIndex();
                break;
            case 7:
                diaLogHolder.SoundOutput();
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
                break;

            case 8:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;

            case 9:
            case 10:
                diaLogHolder.SoundOutput();
                break;
            case 11:
                SetGrabObjectText("카드");
                card.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 12:
                card.SetActive(false);
                pointBox.SetActive(false);
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                AddDialogIndex();
                break;
            case 13:
                diaLogHolder.SoundOutput();
                break;

            default:
                teleportVive.enabled = true;
                EndVRAction();
                break;
        }
    }
}
