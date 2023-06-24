using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public bool canDestroy { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        canDestroy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDestroy && other.gameObject.CompareTag("Spawnable"))
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
