// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;

using BusinessConversation.CHN.Hotel;

public class PeopleCounter : MonoBehaviour
{
    public FadeInOut fadeInOut;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject npcs;
    public Text text;

    public EventArea outEventArea;

    [SerializeField] public int count = 0;

    public void AddCount()
    {
        Debug.Log($"add count : {count}");
        count++;
        if (count >= 4)
        {
            EventCount.currentIndex++;
            PlayerControl.isMoveable = false;

            // fade out
            fadeInOut.FadeOut(() =>
            {
                // player 이동
                player.transform.position = new Vector3(7, 1, -4);
                player.transform.rotation = Quaternion.identity;
                playerCamera.transform.eulerAngles = Vector3.zero;

                // npc 제거
                npcs.SetActive(false);

                // 선생님 대사 변경 (칭찬 & 나가는곳 안내)
                text.text = "정말 잘하셨습니다.\n우측 영역으로 이동하면 퀴즈방으로 이동합니다.";

                // 나가는곳 생성
                outEventArea.gameObject.SetActive(true);
                outEventArea.triggeredAction = () =>
                {
                    PlayerControl.isMoveable = false;
                    fadeInOut.FadeOut(() =>
                    {
                        PlayerControl.isMoveable = true;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        SceneLoader.LoadScene(SceneName._06_Quiz);
                    });

                };

                // fade in
                fadeInOut.FadeIn(() =>
                {
                    PlayerControl.isMoveable = true;
                });
            });
        }
    }
}
