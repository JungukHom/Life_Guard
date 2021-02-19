using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonSixController_AirPort_VR : GameController
{
    public NPCController npcController;
    public TeleportVive teleportVive;

    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                teleportVive.enabled = false;
                AddDialogIndex();
                Action();
                SetVRFirstText();
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
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                diaLogHolder.SoundOutput();
                break;
            default:
                teleportVive.enabled = true;
                EndVRAction();
                break;
        }
    }
}
