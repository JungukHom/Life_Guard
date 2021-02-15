using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonFiveController_VR : GameController
{
    public NPCController npcController;
    public TeleportVive teleportVive;
    public GameObject passport;
    public GameObject pointBox;
    public GameObject dollars;
    public GameObject yuan;

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
            case 3:
                diaLogHolder.SoundOutput();
                break;
            case 4:
                //신분증(여권 건내주기)
                SetGrabObjectText("여권");
                passport.SetActive(true);
                pointBox.SetActive(true);
                break;

            case 5:
                diaLogHolder.SoundOutput();
                break;

            case 6:
                //받는 애니메이션
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                passport.SetActive(false);
                pointBox.SetActive(false);
                diaLogHolder.SoundOutput();
                break;

            case 7:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 8:
            case 9:
                diaLogHolder.SoundOutput();
                break;
            case 10:
                // 돈 건내주기 (Player > npc)
                SetGrabObjectText("달러");
                dollars.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 11:
                //받는 애니메이션
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                dollars.SetActive(false);
                pointBox.SetActive(false);
                diaLogHolder.SoundOutput();
                break;
            case 12:
                // 돈 건내 받기 받는 에니메이션
                SetEventObjectText("위안");
                npcController.SetCharaterState(NPCController.CharaterState.Onemore);
                StartCoroutine(npcController.SetOneMoreState(NPCController.CharaterState.Idel));
                yuan.SetActive(true);
                diaLogHolder.SoundOutput();
                break;

            default:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                teleportVive.enabled = true;
                EndVRAction();
                break;
        }
    }
   

}
