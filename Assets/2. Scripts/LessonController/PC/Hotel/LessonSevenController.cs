using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonSevenController : GameController
{
    public GameObject receipt;
    public GameObject pointBox;
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
                receipt.SetActive(false);
                break;

            default:
                EndAction();
                break;
        }
    }

  
}
