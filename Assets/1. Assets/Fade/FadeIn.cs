using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    //어두운 화면에서 밝게 전환
    public Image fade;
    float fades = 0f;

    Color colorStart = Color.black;
    Color colorEnd = Color.clear;

    public float fadeTime = 0.05f;

    public Action callback = null;

    private void OnEnable()
    {
        fades = 0;
        fade.transform.gameObject.SetActive(true);
        fade.color = Color.clear;

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
                fade.color = Color.clear;
                fade.transform.gameObject.SetActive(false);
                GetComponent<FadeIn>().enabled = false;
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
