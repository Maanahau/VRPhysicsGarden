using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public float newtonValue { get; set; }

    [SerializeField] private Transform barrelTransform;
    [SerializeField] private AudioClip explosionSound;
    private GameObject projectile;
    

    public void Fire()
    {
        if(projectile != null)
        {
            Vector3 force = barrelTransform.forward * newtonValue;
            projectile.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            projectile = null;
            GetComponent<AudioSource>().PlayOneShot(explosionSound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(projectile == null)
        {
            projectile = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (projectile != null)
        {
            projectile = null;
        }
    }
}
