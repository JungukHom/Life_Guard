using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonEightController : GameController
{
    public NPCController npcController;
    public GameObject textUI;
    public GameObject menu;

	private void Start()
	{
        textUI.SetActive(false);
    }

	public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                StartCoroutine("CheckButton");
                AddDialogIndex();
                textUI.SetActive(true);
                SetFirstText();
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
                SetFade();
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1f, 0.6f, 2.5f);
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
            case 14:
                StopCoroutine("CheckButton");
                SetMove();
                SetFade();
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-2.3f, 1f, 2.5f);
                break;
            default:
                GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().enabled = true;
                OutPoint();
                SetEndText();
                this.enabled = false;
                break;
        }
    }

}
