using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeAnimation : MonoBehaviour
{

    private Transform icosphere;
    private Transform gear1;
    private Transform gear2;

    // Start is called before the first frame update
    void Start()
    {
        gear1 = transform.GetChild(0);
        gear2 = transform.GetChild(1);
        icosphere = transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {
        icosphere.Rotate(Vector3.up, 3f * Time.deltaTime, Space.World);
        gear1.Rotate(new Vector3(2f * Time.deltaTime, 10f * Time.deltaTime, 0), Space.World);
        gear2.Rotate(new Vector3(0, 5f * Time.deltaTime, 2f * Time.deltaTime), Space.World);
    }
}
