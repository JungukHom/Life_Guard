// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float duration = 2.0f;
    public Image image;

    private float start = 0.0f;
    private float end = 1.0f;

    public void FadeIn(Action callback = null)
    {
        StartCoroutine(Co_FadeIn(() =>
        {
            callback?.Invoke();
        }));
    }

    public void FadeOut(Action callback = null)
    {
        StartCoroutine(Co_FadeOut(() =>
        {
            callback?.Invoke();
        }));
    }

    private IEnumerator Co_FadeIn(Action callback = null)
    {
        Color color = image.color;

        float time = end;
        while (time >= 0)
        {
            time -= Time.deltaTime / duration;

            float value = Mathf.Lerp(start, end, time);
            color.a = value;

            image.color = color;

            yield return null;
        }

        color.a = 0;
        image.color = color;

        callback?.Invoke();
    }

    private IEnumerator Co_FadeOut(Action callback = null)
    {
        Color color = image.color;

        float time = start;
        while (time <= end)
        {
            time += Time.deltaTime / duration;

            float value = Mathf.Lerp(start, end, time);
            color.a = value;

            image.color = color;

            yield return null;
        }

        color.a = 1;
        image.color = color;

        callback?.Invoke();
    }
}
