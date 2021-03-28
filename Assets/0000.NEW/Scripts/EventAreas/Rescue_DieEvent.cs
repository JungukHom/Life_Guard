// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

public class Rescue_DieEvent : EventArea
{
    public FadeInOut fadeInOut;
    public GameObject player;

    private void Awake()
    {
        triggeredAction = () =>
        {
            fadeInOut.FadeOut(() =>
            {
                player.transform.position = new Vector3(7, 1, -4);
                player.transform.rotation = Quaternion.identity;

                fadeInOut.FadeIn();
            });
        };
    }
}
