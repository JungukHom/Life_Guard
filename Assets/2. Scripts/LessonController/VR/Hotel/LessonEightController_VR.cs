using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LessonEightController_VR : GameController
{
    public NPCController npcController;
    public GameObject textUI;
    public GameObject menu;
    public TeleportVive teleportVive;

    private void Start()
    {
        textUI.SetActive(false);
    }
   
	public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                StartCoroutine("CheckVRButton");
                AddDialogIndex();
                textUI.SetActive(true);
                SetVRFirstText();
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                break;
            case 1:
                npcController.SetCharaterState(NPCController.CharaterState.Greet);
                diaLogHolder.SoundOutput();
                break;
            case 2:
                npcController.SetCharaterState(NPCController.CharaterState.Idel);
                diaLogHolder.SoundOutput();
                break;
            case 3:
                diaLogHolder.SoundOutput();
                break;
            case 4:
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1f, -0.4f, 2.5f);
                AddDialogIndex();
                Action();
                break;
            case 5:
                diaLogHolder.SoundOutput();
                break;
            case 6:
                npcController.SetCharaterState(NPCController.CharaterState.Give);
                menu.SetActive(true);
                diaLogHolder.SoundOutput();
                break;

            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                diaLogHolder.SoundOutput();
                break;

            default:
                teleportVive.enabled = true;
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-2.3f, 0f, 2.5f);
                EndVRAction();
                break;
        }
    }
}
