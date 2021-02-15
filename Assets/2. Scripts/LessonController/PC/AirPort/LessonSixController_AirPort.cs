using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonSixController_AirPort : GameController
{
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
                EndAction();
                break;
        }
    }
}    
    
   
