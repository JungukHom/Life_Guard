using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float rotSpeed = 1f;

    Transform playerTr;
    Transform cameraTr;
    float yaw = 0f;
    float pitch = 0f;
     
    void Start()
    {
        cameraTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 position = playerTr.position;
        position.y = position.y + 0.8f;
        transform.position = position;

        if (PlayerControl.isMoveable)
        {
            yaw += rotSpeed * Input.GetAxis("Mouse X");
            pitch -= rotSpeed * Input.GetAxis("Mouse Y");
            cameraTr.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }
}
