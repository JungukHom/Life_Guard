using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPlayerController : MonoBehaviour
{
    //이동과 관련된 변수
    public float speed = 5f;    
    Vector3 moveDir = Vector3.zero;               
    new Rigidbody rigidbody;
    Transform cameraTr;
    Transform tr;

    //잡는 물체와 관련된 변수
    float rayDistance = 3f;
    RaycastHit hit;
    GameObject collOb;
    Vector3 collObPosition;
    Vector3 collObRotation;
    Rigidbody collRig;
    public float force = 15f;
    public Vector3 grabPosition = new Vector3(-0.35f, 0.5f, 0.4f);

    void Start()
    {
        tr = GetComponent<Transform>();
        cameraTr = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(MouseDown());
    }

    void Update()
    {
        if (PlayerControl.isMoveable)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // normalized
            tr.rotation = Quaternion.Euler(0f, cameraTr.eulerAngles.y, 0f);
            tr.Translate(moveDir * Time.deltaTime * speed, Space.Self);
            //rigidbody.velocity = Vector3.zero; // TODO change velocity
        }
    }


    public EventController_Rescue controllerRescue;
    IEnumerator MouseDown()
    {
        while (true)
        {
            if (collOb == null && Input.GetMouseButtonDown(0))
            {
                Ray ray = new Ray(cameraTr.position, cameraTr.forward);

                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    if (hit.collider.tag.Equals("GrabableObject"))
                    {
                        collOb = hit.collider.gameObject;
                        Transform colliderTr = collOb.transform;
                        collObPosition = colliderTr.position;
                        collObRotation = colliderTr.eulerAngles;
                        collRig = collOb.GetComponent<Rigidbody>();
                        colliderTr.parent = gameObject.transform;
                        colliderTr.localPosition = grabPosition;
                        colliderTr.rotation = Quaternion.identity;

                        colliderTr.parent = cameraTr.transform;

                        SetCollRigid();
                    }
                    else if (hit.collider.gameObject.name.Equals("RescueReset"))
                    {
                        controllerRescue.ResetObjectPositions();
                    }
                    else if (hit.collider.tag.Equals("EventObject"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0) && collOb != null)
            {
                Ray ray = new Ray(cameraTr.position, cameraTr.forward);

                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    if (hit.collider.tag.Equals("Point"))
                    {
                        collOb.transform.position = hit.collider.transform.position;
                    }
                    else
                    {
                        collOb.transform.position = collObPosition;
                    }
                }
                else
                {
                    collOb.transform.position = collObPosition;
                }
                collOb.transform.rotation = Quaternion.Euler(collObRotation);
                SetCollRigid();
                collOb.transform.parent = null;
                ResetCollOb();
            }
            else if (Input.GetMouseButtonDown(1) && collOb != null)
            {
                SetCollRigid();
                collOb.transform.parent = null;
                Vector3 throwVector = cameraTr.up + cameraTr.forward * force;
                throwVector.y = throwVector.y * 0.025f;
                collRig.AddForce(throwVector, ForceMode.Impulse);
                ResetCollOb();
            }
            yield return null;
        }
    }

    void ResetCollOb()
    {
        collOb = null;
        collRig = null;
    }

    void SetCollRigid()
    {
        collRig.useGravity = !collRig.useGravity;
        collRig.isKinematic = !collRig.isKinematic;
    }
}



