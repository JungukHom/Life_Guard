namespace RESC
{
    // C#
    using System.Collections;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    using static UnityEngine.UI.Button;

    // Project
    // Alias

    public class Pointer : MonoBehaviour
    {
        public float DefaultLength = 10.0f;
        public GameObject dot;
        public VRInputModule inputModule;

        private LineRenderer lineRenderer;

        private void Awake()
        {
            FindComponents();
        }

        private void FindComponents()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            UpdateLine();
        }

        private void UpdateLine()
        {
            PointerEventData data = inputModule.GetData();

            float targetLength = data.pointerCurrentRaycast.distance == 0 ? DefaultLength : data.pointerCurrentRaycast.distance;
            RaycastHit hit = CreateRaycast(targetLength);
            Vector3 endPosition = transform.position + (transform.forward * targetLength);
            if (hit.collider != null && hit.collider.CompareTag("VRButton"))
            {
                endPosition = hit.point;
                hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
            }
            dot.transform.position = endPosition;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, endPosition);
        }

        private RaycastHit CreateRaycast(float length)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Physics.Raycast(ray, out RaycastHit hit, length);

            return hit;
        }
    }
}
