using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
    //밝은화면에서 어둡게 전환하는 코드

    public Image fade;
    float fades = 0f;

    Color colorStart = Color.clear;
    Color colorEnd = Color.black;

    public float fadeTime = 0.05f;

    public Action callback = null;

    private void OnEnable()
    {
        fades = 0;
        fade.transform.gameObject.SetActive(true);
        fade.color = Color.black;

        StartCoroutine(SetFade());
    }
    private void Awake()
    {
        callback = () =>
        {
            Debug.Log("callback");
        };
    }

    IEnumerator SetFade()
    {
        while (fades < 1f)
        {
            fades += 0.05f;
            fade.color = Color.Lerp(colorStart, colorEnd, fades);

            if (fades > 1f)
            {
                fade.color = Color.black;
                GetComponent<FadeOut>().enabled = false;
                fades = 0f;
                break;
            }
            yield return new WaitForSeconds(fadeTime);
        }

        callback?.Invoke();

        yield return null;
    }
    private void OnDisable()
    {
        StopCoroutine(SetFade());
    }

}
