using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonSevenController_VR : GameController
{
    public GameObject receipt;
    public GameObject pointBox;
    public NPCController npcController;
    public TeleportVive teleportVive;

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
                receipt.SetActive(true);
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                break;

            case 3:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;

            case 4:
            case 5:
            case 6:
            case 7:
                diaLogHolder.SoundOutput();
                break;

            default:
                teleportVive.enabled = true;
                EndVRAction();
                break;
        }
    }
}
