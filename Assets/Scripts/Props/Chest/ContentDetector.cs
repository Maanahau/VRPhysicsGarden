using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentDetector : MonoBehaviour
{
    [SerializeField] GameObject content;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision");
        if(other.gameObject == content || other.transform.IsChildOf(content.transform))
        {
            content.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}
