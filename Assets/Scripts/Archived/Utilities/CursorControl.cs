namespace BusinessConversation.CHN.Hotel
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Project
    // Alias

    public class CursorControl : MonoBehaviour
    {
        public static void VisibleMode()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public static void InvisibleMode()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
