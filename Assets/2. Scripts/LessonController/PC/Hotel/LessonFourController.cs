﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonFourController : GameController
{
    public override void Action()
    {
        switch (dialogIndex)
        {
            case 0:
                FristAction();
                break;
            case 1:
                StartCoroutine("CheckButton");
                AddDialogIndex();
                break;
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                diaLogHolder.SoundOutput();
                break;

            default:
                EndAction();
                break;
        }
    }
}
