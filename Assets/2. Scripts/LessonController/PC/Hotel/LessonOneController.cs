﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonOneController : GameController
{
    public GameObject passport;
    public GameObject pointBox;
    public NPCController npcController;
    public GameObject roomKey;
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
                diaLogHolder.SoundOutput();
                break;
            case 4:
                npcController.SetCharaterState(NPCController.CharaterState.Typing);
                diaLogHolder.SoundOutput();
                break;
            case 5:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 6:
                diaLogHolder.SoundOutput();
                break;
            case 7:
                //여권 NPC 한테 주기 
                SetGrabObjectText("여권");
                passport.SetActive(true);
                pointBox.SetActive(true);
                break;
            case 8:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                passport.SetActive(false);
                pointBox.SetActive(false);
                diaLogHolder.SoundOutput();
                break;
            case 9:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 10:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                SetEventObjectText("방키");
                roomKey.SetActive(true);
                break;
            case 11:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 12:
                npcController.SetCharaterState(NPCController.CharaterState.Greet);
                AddDialogIndex();
                Action();
                break;
            default:
                EndAction();
                break;
        }
    }
}
