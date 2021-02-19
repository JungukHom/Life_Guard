using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class GameController : MonoBehaviour
{
    public Fade fade;
    public PCPlayerController pcPlayerContoller;
    public DiaLogHolder diaLogHolder;
    public GameObject outPoint;
    
    public int dialogIndex = 0;
    TextMeshProUGUI text;
    
    public virtual void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    protected void SetMove()
    {
        pcPlayerContoller.enabled = !pcPlayerContoller.enabled;
    }

    protected void SetFade()
    {
        fade.enabled = true;
    }

    public void AddDialogIndex()
    {
        dialogIndex++;
    }
    public IEnumerator CheckButton()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Action();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                diaLogHolder.Replay();
            }

            yield return null;
        }
    }

    public void SetFirstText()
	{
        text = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        text.text = "대화진행은 'E', 상호작용은 마우스 왼쪽버튼입니다. \n대사를 다시 듣고싶으시면 'R'키를 누르세요";
    }

    public void SetVRFirstText()
    {
        text = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        text.text = "대화진행과 상호작용은 Trigger 버튼입니다. \n대사를 다시 듣고싶으시면 Trackpad를 누르세요";
    }

    public void SetGrabObjectText(string objectName)
    {
        text = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        text.text = objectName + "을(를) Point에 놓으시오.";
    }

    public void SetEventObjectText(string objectName)
    {
        text = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        text.text = objectName + "을(를) 집으시오.";
    }

    public void SetEndText()
    {
        text = GameObject.FindGameObjectWithTag("TextCanvas").GetComponentInChildren<TextMeshProUGUI>();
        text.text = "모든 대화가 종료되었습니다. 바닥의 Point로 이동하세요.";
    }

    public void FristAction()
    {
        SetFirstText();
        SetFade();
        SetMove();
    }

    public void EndAction()
    {
        StopCoroutine("CheckButton");
        SetEndText();
        SetMove();
        OutPoint();
        this.enabled = false;
    }

    public void OutPoint()
	{
        outPoint.SetActive(true);
    }

    public void EndVRAction()
    {
        StopCoroutine("CheckVRButton");
        SetEndText();
        OutPoint();
        this.enabled = false;
    }

    public IEnumerator CheckVRButton()
    {
        // TODO : 주석 풀기
        yield return null;
        //SteamVR_Action_Boolean trigger = SteamVR_Actions.default_GrabPinch;
        //SteamVR_Action_Boolean trackpad = SteamVR_Actions.default_Teleport;

        //while (true)
        //{
        //    if (trigger.GetLastStateDown(SteamVR_Input_Sources.Any))
        //    {
        //        Action();
        //    }

        //    if (trackpad.GetLastStateDown(SteamVR_Input_Sources.Any))
        //    {
        //        diaLogHolder.Replay();
        //    }

        //    yield return null;
        //}
    }

}