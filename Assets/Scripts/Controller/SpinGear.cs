using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGear : MonoBehaviour
{
    [SerializeField] GameObject gear;
    [SerializeField] bool invert;
    void Update()
    {
        if (invert)
        {
            gear.transform.Rotate(Vector3.forward, 20f * Time.deltaTime);
        }
        else
        {
            gear.transform.Rotate(Vector3.forward, -20f * Time.deltaTime);
        }
    }
}
