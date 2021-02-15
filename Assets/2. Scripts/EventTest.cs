using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventTest : MonoBehaviour
{
    public Action callback = null;
    GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void TriggerEnter()
    {
        Vector3 _position = transform.position;
        _position.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        GameObject.FindGameObjectWithTag("Player").transform.position = _position;
        gameController.Action();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            other.transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            Camera.main.transform.rotation = Quaternion.Euler(other.transform.eulerAngles);
            gameController.Action();
            gameObject.SetActive(false);
        }
       
    }
}
