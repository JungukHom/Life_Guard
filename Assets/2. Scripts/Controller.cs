using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Controller : MonoBehaviour
{
    public SteamVR_Action_Boolean grip;

    SteamVR_Behaviour_Pose myHand = null;

    Transform myTr = null;
    Rigidbody myRig = null;

    Rigidbody currentRigidbody = null;
    List<Rigidbody> contactRigidbodies = new List<Rigidbody>();

    GameController gameController;

    GameObject eObj;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        myHand = GetComponent<SteamVR_Behaviour_Pose>();
        myTr = GetComponent<Transform>();
        myRig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grip.GetStateDown(myHand.inputSource))
        {
            PickUp();
            EventObject();
        }

        if (grip.GetStateUp(myHand.inputSource))
        {
            Drop();
        }
    }

    public void PickUp()
    {
        currentRigidbody = GetNearestRigidBody();

        if (currentRigidbody == null) return;

        currentRigidbody.useGravity = false;
        currentRigidbody.isKinematic = true;

        currentRigidbody.transform.position = myTr.position;
        currentRigidbody.transform.parent = myTr;
    }

    public void Drop()
    {
        if (currentRigidbody == null) return;

        currentRigidbody.useGravity = true;
        currentRigidbody.isKinematic = false;

        currentRigidbody.transform.parent = null;

        currentRigidbody.velocity = myHand.GetVelocity();
        currentRigidbody.angularVelocity = myHand.GetAngularVelocity();

        currentRigidbody = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("GrabableObject"))
        {
            contactRigidbodies.Add(other.gameObject.GetComponent<Rigidbody>());
        }
        else if (other.transform.CompareTag("EventObject"))
        {
            eObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("GrabableObject"))
        {
            contactRigidbodies.Remove(other.gameObject.GetComponent<Rigidbody>());
        }
        else if (other.transform.CompareTag("EventObject"))
        {
            eObj = null;
        }
    }

    Rigidbody GetNearestRigidBody()
    {
        Rigidbody nearestRigidBody = null;

        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Rigidbody rigidbody in contactRigidbodies)
        {
            distance = (rigidbody.transform.position - myTr.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestRigidBody = rigidbody;
            }
        }

        return nearestRigidBody;
    }

    public void EventObject()
    {
        if (eObj != null)
        {
            Destroy(eObj);
            gameController.AddDialogIndex();
            gameController.Action();
        }
    }
}

