namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class _05_Temp : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Screen.NotifySceneLoaded();
            CursorControl.InvisibleMode();
        }
    }
}
