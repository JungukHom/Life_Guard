namespace BusinessConversation.CHN.Hotel
{
    using System;
    // C#
    using System.Collections;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;

    public class Screen : MonoBehaviour
    {
        private static Screen _instance = null;

        private readonly float start = 0.0f;
        private readonly float end = 1.0f;

        private Image backgroundImage = null;

        private const float defaultDuration = 1.0f;
        private const float defaultDelay = 0.0f;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _instance = this;
            DontDestroyOnLoad(transform);
            FindComponents();
        }

        private void FindComponents()
        {
            backgroundImage = GetComponentInChildren<Image>();
        }

        public static void NotifySceneLoaded(Action callback = null)
        {
            FadeIn(() => { callback?.Invoke(); });
        }

        public static void FadeIn(Action callback)
        {
            _instance.FadeInWarpper(defaultDuration, defaultDelay, () =>
            {
                callback?.Invoke();
            });
        }

        public static void FadeOut(Action callback)
        {
            _instance.FadeOutWrapper(defaultDuration, defaultDelay, () =>
            {
                callback?.Invoke();
            });
        }

        public static void FadeIn(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            _instance.FadeInWarpper(duration, delay, () =>
            {
                callback?.Invoke();
            });
        }

        public static void FadeOut(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            _instance.FadeOutWrapper(duration, delay, () =>
            {
                callback?.Invoke();
            });
        }

        private void FadeInWarpper(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            StopAllCoroutines();
            StartCoroutine(EFadeIn(duration, delay, () =>
            {
                callback?.Invoke();
            }));
        }

        private void FadeOutWrapper(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            StopAllCoroutines();
            StartCoroutine(EFadeOut(duration, delay, () =>
            {
                callback?.Invoke();
            }));
        }

        private IEnumerator EFadeIn(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            Color color = backgroundImage.color;

            float time = start;
            while (color.a > start)
            {
                time += Time.deltaTime / duration;
                color.a = Mathf.Lerp(end, start, time);
                backgroundImage.color = color;
                yield return null;
            }

            Color endColor = new Color(0, 0, 0, 0);
            backgroundImage.color = endColor;
            backgroundImage.raycastTarget = false;

            callback?.Invoke();
        }

        private IEnumerator EFadeOut(float duration = defaultDuration, float delay = defaultDelay, Action callback = null)
        {
            backgroundImage.raycastTarget = true;

            Color color = backgroundImage.color;

            float time = start;
            while (color.a < end)
            {
                time += Time.deltaTime / duration;
                color.a = Mathf.Lerp(start, end, time);
                backgroundImage.color = color;
                yield return null;
            }

            Color startColor = new Color(0, 0, 0, 1);
            backgroundImage.color = startColor;

            callback?.Invoke();
        }
    }
}
