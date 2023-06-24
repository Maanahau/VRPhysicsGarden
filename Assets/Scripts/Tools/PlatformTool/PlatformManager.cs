using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject ghostPlatformPrefab;
    [SerializeField] [Tooltip("Spawn distance")] float platformOffset;
    [SerializeField] GameObject raycastOrigin;
    [SerializeField] [Tooltip("Wood")] Material defaultMaterial;
    [SerializeField] [Tooltip("Wood")] PhysicMaterial defaultPhysicMaterial;

    [SerializeField] GameObject angleSlider;
    [SerializeField] GameObject snapToggle;
    public Material selectedMaterial { get; set; }
    public PhysicMaterial selectedPhysicMaterial { get; set; }

    private float selectedAngle;

    private GameObject ghostPlatform;
    private RaycastHit hit;
    private bool snapMode = true;

    private void Awake()
    {
        selectedMaterial = defaultMaterial;
        selectedPhysicMaterial = defaultPhysicMaterial;
    }

    void Update()
    {
        if(Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.forward, out hit, platformOffset)
            && hit.collider.gameObject.tag == "SnapSocket" && snapMode)
        {
            //snap to other platform
            ghostPlatform.transform.rotation = hit.collider.transform.parent.transform.rotation;
            ghostPlatform.transform.position = hit.collider.transform.parent.transform.position + hit.collider.transform.forward;
        }
        else
        {
            //no snapping
            ghostPlatform.transform.position = gameObject.transform.position + (gameObject.transform.forward * platformOffset);
            ghostPlatform.transform.eulerAngles = new Vector3(-selectedAngle, gameObject.transform.rotation.eulerAngles.y, 0);
        }
    }

    public void Init()
    {
        ghostPlatform = Instantiate(ghostPlatformPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void DestroyGhostPlatform()
    {
        Destroy(ghostPlatform);
    }

    public void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(platformPrefab, ghostPlatform.transform.position, ghostPlatform.transform.rotation);
        newPlatform.GetComponent<MeshRenderer>().material = selectedMaterial;
        newPlatform.GetComponent<BoxCollider>().material = selectedPhysicMaterial;
    }

    //call on value changed in the angle slider
    public void getAngleFromSlider()
    {
        selectedAngle = angleSlider.GetComponent<Slider>().value;
        selectedAngle = (float)System.Math.Round(selectedAngle, 1);
    }

    public void getSnapValue()
    {
        snapMode = snapToggle.GetComponent<Toggle>().isOn;
    }
}
