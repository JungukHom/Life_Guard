using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonOneController_AirPort : GameController
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
                break;
            case 3:
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
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
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                EndAction();
                break;
        }
    }
}    
    
   
