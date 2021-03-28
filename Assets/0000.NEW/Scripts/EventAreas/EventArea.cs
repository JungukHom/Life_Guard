// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EventArea : MonoBehaviour
{
    [SerializeField] private int index = 0;
    [SerializeField] private string targetTag = "Player";

    public Action triggeredAction = null;

    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        gameObject.tag = "EventArea";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            triggeredAction?.Invoke();

            //Destroy(boxCollider);
            // Do something
        }
    }
}
