// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

public class HelpEvent : EventArea
{
    public PeopleCounter counter;

    private void Awake()
    {
        triggeredAction = () =>
        {
            counter.AddCount();
        };
    }
}
