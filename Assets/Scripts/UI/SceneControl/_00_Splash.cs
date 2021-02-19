namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;

    // Unity
    using UnityEngine;

    public class _00_Splash : MonoBehaviour
    {
        private void Awake()
        {
            CursorControl.InvisibleMode();
        }

        private void Start()
        {
            Screen.FadeIn(1.0f, 1.0f, () =>
            {
                StartCoroutine(WaitAndMoveScene(1.0f));
            });            
        }

        private IEnumerator WaitAndMoveScene(float delay)
        {
            yield return new WaitForSeconds(delay);
            Screen.FadeOut(1.0f, 1.0f, () =>
            {
                SceneLoader.LoadScene(SceneName._01_Title);
            });
        }
    }
}
