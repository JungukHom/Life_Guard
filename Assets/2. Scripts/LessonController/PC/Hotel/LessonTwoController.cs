using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonTwoController : GameController
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
            case 4:
                diaLogHolder.SoundOutput();
                break;
            case 5:
                //키보드 누르기
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
                diaLogHolder.SoundOutput();
                break;
            case 6:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
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
