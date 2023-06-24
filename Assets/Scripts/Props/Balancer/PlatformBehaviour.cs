using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balancer
{
    public class PlatformBehaviour : MonoBehaviour
    {
        private List<GameObject> touchingObjects;

        private void Awake()
        {
            touchingObjects = new List<GameObject>();
        }

        public float GetTotalMass()
        {
            bool deletedObjects = false;
            float totalMass = 0;
            foreach(GameObject obj in touchingObjects){
                if(obj == null)
                {
                    deletedObjects = true;
                    continue;
                }
                totalMass += obj.GetComponent<Rigidbody>().mass;
            }
            if (deletedObjects)
            {
                foreach(GameObject obj in touchingObjects)
                {
                    if (obj == null)
                        touchingObjects.Remove(obj);
                }
            }
            return totalMass;
        }

        private void OnCollisionEnter(Collision collision)
        {
            
            touchingObjects.Add(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            touchingObjects.Remove(collision.gameObject);
        }

    }
}

