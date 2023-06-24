using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - head.position;
        if(Vector3.Magnitude(direction) < 20)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            head.rotation = Quaternion.Slerp(head.rotation, rotation, 5f * Time.deltaTime);
        }
    }
}
