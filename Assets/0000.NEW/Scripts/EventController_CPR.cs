// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

using BusinessConversation.CHN.Hotel;

public class EventController_CPR : MonoBehaviour
{
    public EventArea outArea;
    public FadeInOut fade;

    private void Awake()
    {
        outArea.triggeredAction = () =>
        {
            PlayerControl.isMoveable = false;
            fade.FadeOut(() =>
            {
                PlayerControl.isMoveable = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneLoader.LoadScene(SceneName._06_Quiz);
            });
        };
    }
}
