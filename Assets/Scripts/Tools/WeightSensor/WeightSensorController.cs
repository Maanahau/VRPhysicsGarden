using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightSensorController : MonoBehaviour
{
    [SerializeField] float maxRaycastDistance;
    [SerializeField] Transform rayOriginTransform;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] LayerMask raycastHitLayerMask;
    [SerializeField] LineRenderer lineRenderer;

    private RaycastHit hit;
    [HideInInspector] public float measuredMass;

    private void Update()
    {
        Vector3[] linePositions = new Vector3[2];
        linePositions[0] = rayOriginTransform.position;
        linePositions[1] = rayOriginTransform.position + rayOriginTransform.forward * maxRaycastDistance;
        lineRenderer.SetPositions(linePositions);
        if (Physics.Raycast(rayOriginTransform.position, rayOriginTransform.forward, out hit, maxRaycastDistance, raycastHitLayerMask))
        {
            Rigidbody rigidBody = hit.transform.GetComponent<Rigidbody>();
            if (rigidBody)
            {
                measuredMass = (float) System.Math.Round(rigidBody.mass, 2);
                textBox.text = measuredMass + " Kg";
            }
            else
            {
                textBox.text = "";
            }
        }
    }

    public void OnActivate()
    {
        Vector3[] linePositions = new Vector3[2];
        linePositions[0] = rayOriginTransform.position;
        linePositions[1] = rayOriginTransform.position + rayOriginTransform.forward * maxRaycastDistance;
        lineRenderer.SetPositions(linePositions);

        lineRenderer.enabled = true;
        this.enabled = true;
    }

    public void OnDeactivate()
    {
        this.enabled = false;
        lineRenderer.enabled = false;
    }

}
