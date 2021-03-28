using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private void Start()
    {
        EventCount.currentIndex = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
