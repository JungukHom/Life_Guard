namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    public class SinMovement : MonoBehaviour
    {
        private float speed = 3.0f;
        private float length = 0.1f;

        private float runningTime = 0.0f;
        private float yPos = 0.0f;

        private bool isLanded = false;

        Vector3 defaultPosition;
        Quaternion defaultRotation;

        private void Awake()
        {
            defaultPosition = transform.position;
            defaultRotation = transform.rotation;
        }

        private void Update()
        {
            if (isLanded)
            {
                runningTime += Time.deltaTime * speed;
                yPos = Mathf.Sin(runningTime) * length;
                this.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            }
        }

        public void ResetState()
        {
            transform.position = defaultPosition;
            transform.rotation = defaultRotation;

            isLanded = false;

            Rigidbody rb = GetComponent<Rigidbody>();
            Collider collider = GetComponent<Collider>();

            rb.useGravity = true;
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;

            collider.isTrigger = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("WaterLine"))
            {
                isLanded = true;

                this.transform.rotation = Quaternion.identity;

                Rigidbody rb = GetComponent<Rigidbody>();
                Collider collider = GetComponent<Collider>();

                rb.useGravity = false;
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;

                collider.isTrigger = true;
            }
        }
    }
}
