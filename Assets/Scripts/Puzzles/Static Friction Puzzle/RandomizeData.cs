using UnityEngine;

public class RandomizeData : MonoBehaviour
{
    [SerializeField] GameObject sampleCube;
    [SerializeField] GameObject plane;

    //randomizer constants
    const float minMass = 1f;
    const float maxMass = 25f;


    private void Awake()
    {
        //random color
        sampleCube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.6f, 1f, 1f, 1f);
        plane.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.6f, 1f, 1f, 1f);

        //random cube mass
        sampleCube.GetComponent<Rigidbody>().mass = Random.Range(minMass, maxMass);

        //random friction values
        PhysicMaterial cubePhysicMaterial = sampleCube.GetComponent<BoxCollider>().material;
        PhysicMaterial planePhysicMaterial = plane.GetComponent<BoxCollider>().material;

        cubePhysicMaterial.staticFriction = Random.Range(0f, 1f);
        cubePhysicMaterial.dynamicFriction = Random.Range(cubePhysicMaterial.staticFriction * 0.2f, cubePhysicMaterial.staticFriction);
        planePhysicMaterial.staticFriction = Random.Range(0f, 1f);
        planePhysicMaterial.dynamicFriction = Random.Range(planePhysicMaterial.staticFriction * 0.2f, planePhysicMaterial.staticFriction);
    }
}
