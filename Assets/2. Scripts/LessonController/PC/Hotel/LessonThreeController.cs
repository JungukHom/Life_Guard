using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonThreeController : GameController
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
            case 3:
                diaLogHolder.SoundOutput();
                break;
            case 4:
                //타이핑하기
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
                diaLogHolder.SoundOutput();
                break;
            case 5:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 6:
            case 7:
                diaLogHolder.SoundOutput();
                break;
            default:
                EndAction();
                break;
        }
    }
  
}
