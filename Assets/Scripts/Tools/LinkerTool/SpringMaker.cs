using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMaker : MonoBehaviour
{
    [SerializeField] private GameObject springPrefab;

    private const float springLength = 0.5f;

    public void CreateSpring(GameObject[] sockets)
    {
        //if both selected objects are kinematic don't spawn the spring
        if (sockets[0].transform.parent.GetComponent<Rigidbody>().isKinematic &&
            sockets[1].transform.parent.GetComponent<Rigidbody>().isKinematic)
            return;

        LinkSocketProperties[] socketProperties = new LinkSocketProperties[2];
        socketProperties[0] = sockets[0].GetComponent<LinkSocketProperties>();
        socketProperties[1] = sockets[1].GetComponent<LinkSocketProperties>();

        socketProperties[0].busy = true;
        socketProperties[1].busy = true;

        Transform springTransform = sockets[0].transform;
        springTransform.LookAt(sockets[1].transform);

        //instantiate model prefab
        GameObject spring = Instantiate(springPrefab, sockets[0].transform.position, springTransform.rotation);

        //move selected objects near each other at a distance of 0.5 (springLength)
        if(sockets[1].transform.parent.GetComponent<Rigidbody>().isKinematic == false)
        {
            //if second selected object isn't kinematic
            float socketDistance = Vector3.Distance(sockets[0].transform.position, sockets[1].transform.position);
            Transform linkedObjectTransform = sockets[1].transform.parent.transform;

            linkedObjectTransform.LookAt(sockets[0].transform.parent.transform);
            sockets[1].transform.parent.transform.Translate(linkedObjectTransform.forward * (socketDistance - springLength), Space.World);
        }
        else
        {
            //if second selected object IS kinematic
            float socketDistance = Vector3.Distance(sockets[0].transform.position, sockets[1].transform.position);
            Transform linkedObjectTransform = sockets[0].transform.parent.transform;

            linkedObjectTransform.LookAt(sockets[1].transform.parent.transform);
            sockets[0].transform.parent.transform.Translate(linkedObjectTransform.forward * (socketDistance - springLength), Space.World);
        }

        GameObject joint = spring.transform.GetChild(1).gameObject;
        SpringJoint[] springJoints = joint.GetComponents<SpringJoint>();
        
        springJoints[0].connectedBody = sockets[1].transform.parent.gameObject.GetComponent<Rigidbody>();
        springJoints[1].connectedBody = sockets[0].transform.parent.gameObject.GetComponent<Rigidbody>();

        //copy sockets data in sockets and spring
        socketProperties[0].linkedObject = spring;
        socketProperties[1].linkedObject = spring;
        spring.transform.GetChild(0).GetComponent<SpringManager>().sockets = (GameObject[]) sockets.Clone();
    }
        
}
