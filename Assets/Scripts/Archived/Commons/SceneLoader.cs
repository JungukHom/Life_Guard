namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class SceneLoader : MonoBehaviour
    {
        public Text progressText;
        public Image progressBarFill;

        private static string nextSceneName = "";
        private static readonly string LoadingSceneName = SceneName._99_Loading;

        private float loadingPrecent = 0.0f;

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void LoadSceneAsync(string sceneName)
        {
            nextSceneName = sceneName;
            SceneManager.LoadScene(LoadingSceneName);
        }

        private void Start()
        {
            Screen.NotifySceneLoaded(() =>
            {
                StartCoroutine(LoadScene());
            });
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1.0f);

            AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
            operation.allowSceneActivation = false;

            float timer = 0.0f;
            while (!operation.isDone)
            {
                timer += Time.deltaTime;

                if (operation.progress < 0.9f)
                {
                    loadingPrecent = Mathf.Lerp(loadingPrecent, operation.progress, timer);
                    progressBarFill.fillAmount = loadingPrecent;
                    progressText.text = $"{loadingPrecent * 100}%";
                    if (loadingPrecent >= operation.progress)
                    {
                        timer = 0.0f;
                    }
                }
                else
                {
                    loadingPrecent = Mathf.Lerp(loadingPrecent, 1.0f, timer);
                    progressBarFill.fillAmount = loadingPrecent;
                    progressText.text = $"{loadingPrecent * 100}%";
                    if (loadingPrecent == 1.0f)
                    {
                        yield return new WaitForSeconds(1.0f);
                        Screen.FadeOut(1.0f, 0.0f, () =>
                        {
                            operation.allowSceneActivation = true;
                        });

                        yield break;
                    }
                }
            }
        }
    }
}
