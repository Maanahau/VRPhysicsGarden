using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform playerCamera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera);
    }
}
