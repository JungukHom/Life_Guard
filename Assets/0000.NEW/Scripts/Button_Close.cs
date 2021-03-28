// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Button_Close : MonoBehaviour
{
    public GameObject destroyTarget;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnClick());
    }

    private void OnClick()
    {
        Destroy(destroyTarget);
    }
}