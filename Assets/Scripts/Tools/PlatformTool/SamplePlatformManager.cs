using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlatformManager : MonoBehaviour
{
    [SerializeField] GameObject samplePlatform;
    private PlatformManager platformManager;

    private void Awake()
    {
        platformManager = gameObject.GetComponent<PlatformManager>();
    }

    private void Update()
    {
        samplePlatform.transform.Rotate(Vector3.up, 150f * Time.deltaTime);
    }

    public void updateSampleMaterial()
    {
        samplePlatform.GetComponent<MeshRenderer>().material = platformManager.selectedMaterial;
    }
}
