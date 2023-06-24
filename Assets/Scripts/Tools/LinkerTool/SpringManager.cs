using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour
{
    public GameObject[] sockets;

    private GameObject springModel;

    private void Start()
    {
        springModel = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        gameObject.transform.LookAt(sockets[1].transform);
        gameObject.transform.position = sockets[0].transform.position;

        springModel.transform.position = (sockets[0].transform.position + sockets[1].transform.position) / 2;
        float socketDistance = Vector3.Distance(sockets[0].transform.position, sockets[1].transform.position);
        springModel.transform.localScale = new Vector3(1f, 1f, socketDistance * 2);
    }

} 