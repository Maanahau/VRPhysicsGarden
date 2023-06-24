using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExcept : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spawnable" && other.gameObject != obj)
            Destroy(other.gameObject);
    }
}
