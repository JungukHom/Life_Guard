// C#
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

// Project
using Valve.VR;

// Alias

public class Fade : MonoBehaviour
{
    public float fadeTime = 1f;

    public void StartFade()
    {
        StopAllCoroutines();
        StartCoroutine(SetFade());
    }

    IEnumerator SetFade()
    {
        SteamVR_Fade.Start(Color.black, fadeTime, true);
        yield return new WaitForSeconds(fadeTime);

        SteamVR_Fade.Start(Color.clear, fadeTime, true);
        yield return new WaitForSeconds(fadeTime);

        yield return null;
    }
}