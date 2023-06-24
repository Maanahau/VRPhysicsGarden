using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMovingParts : MonoBehaviour
{
    [SerializeField] GameObject[] movingParts;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        movingParts[0].transform.Rotate(movingParts[0].transform.forward, speed * Time.deltaTime, Space.World);
        movingParts[1].transform.Rotate(movingParts[1].transform.forward, -speed * Time.deltaTime, Space.World);
    }
}
