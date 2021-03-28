// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

public class EventController_Rescue : MonoBehaviour
{
    public GameObject[] grabableObjects;

    private Transform[] grabableObjectPositions;

    private void Awake()
    {
        grabableObjectPositions = new Transform[grabableObjects.Length];
        for (int i = 0 ; i <grabableObjects.Length; i++)
        {
            grabableObjectPositions[i] = grabableObjects[i].transform;
        }
    }

    public void ResetObjectPositions()
    {
        FindObjectOfType<PeopleCounter>().count = 0;

        for (int i = 0; i < grabableObjects.Length; i++)
        {
            grabableObjects[i].transform.position = grabableObjectPositions[i].position;
            grabableObjects[i].transform.rotation = grabableObjectPositions[i].rotation;

            RESC.SinMovement movement = grabableObjects[i].GetComponent<RESC.SinMovement>();
            movement.ResetState();
        }
    }
}
