using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{

    public GameObject shootPosition;
    public bool canShoot { get; set; }

    //object properties

    public GameObject defaultPrefab;
    public Material defaultMaterial;

    //get these from the menu
    public GameObject selectedPrefab { get; set; }
    public PhysicMaterial selectedPhysicMaterial { get; set; }
    public Material selectedMaterial { get; set; }

    public GameObject sizeSlider;
    public GameObject massSlider;

    private Slider sizeSliderComponent;
    private Slider massSliderComponent;

    //need public for monitorManager
    public float selectedSize;
    public float selectedMass;

    private void Start()
    {
        //default settings
        selectedPrefab = defaultPrefab;
        selectedMaterial = defaultMaterial;
        selectedMass = 1;
        selectedSize = 10;
        canShoot = true;

        sizeSliderComponent = sizeSlider.GetComponent<Slider>();
        massSliderComponent = massSlider.GetComponent<Slider>();
    }

    //call this function when pressed confirm on menu
    public void checkSelection()
    {
        //copy prefab if selected and change its properties
        if (!selectedPrefab)
            selectedPrefab = defaultPrefab;    
        canShoot = true;

        //don't move from here the monitorManager won't work
        if (!selectedMaterial)
        {
            selectedMaterial = defaultMaterial;
        }
        selectedSize = (float)System.Math.Round(sizeSliderComponent.value, 1);
        selectedMass = (float)System.Math.Round(massSliderComponent.value, 1);
    }
    public void SpawnSelectedObject()
    {
        if (canShoot)
        {
            Transform newTransform = shootPosition.transform;
            GameObject spawnedObject = Instantiate(selectedPrefab, newTransform.position, newTransform.rotation);

            if (selectedMaterial)
            { 
                spawnedObject.GetComponent<MeshRenderer>().material = selectedMaterial;
                spawnedObject.GetComponent<Collider>().material = selectedPhysicMaterial;
            }

            float normalizedSize = selectedSize / 100;
            spawnedObject.transform.localScale = new Vector3(normalizedSize, normalizedSize, normalizedSize);
            spawnedObject.GetComponent<Rigidbody>().mass = selectedMass;
        }
    }
}
