using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBox : MonoBehaviour
{
    GameController gameController;
	private void Start()
	{
       gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "GrabableObject")
        {
            gameController.AddDialogIndex();
            gameController.Action();
        }
        
    }
}
