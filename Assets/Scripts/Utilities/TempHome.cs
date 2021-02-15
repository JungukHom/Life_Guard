namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class TempHome : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Screen.FadeOut(() =>
                {
                    SceneLoader.LoadScene(SceneName._01_Title);
                });
            }
        }
    }
}
