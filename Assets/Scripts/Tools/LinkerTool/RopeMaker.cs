using UnityEngine;

public class RopeMaker : MonoBehaviour
{
    [SerializeField] private GameObject ropePrefab;
    [SerializeField] private GameObject ropeSegmentPrefab;
    [SerializeField] private GameObject ropeEdgePrefab;
    [SerializeField] [Tooltip("Segments per meter")] private float segmentDensity; //segments per meter

    public void CreateRope(GameObject[] sockets)
    {
        LinkSocketProperties[] socketProperties = new LinkSocketProperties[2];
        socketProperties[0] = sockets[0].GetComponent<LinkSocketProperties>();
        socketProperties[1] = sockets[1].GetComponent<LinkSocketProperties>();

        socketProperties[0].busy = true;
        socketProperties[1].busy = true;

        GameObject rope = Instantiate(ropePrefab);

        //number of segments in the rope
        float length = Vector3.Distance(sockets[0].transform.position, sockets[1].transform.position);
        int segmentNumber = Mathf.FloorToInt(length * segmentDensity);
        float segmentDistance = length / segmentNumber;

        //create segments and attach them to the rope
        Transform ropeGrowDirection = sockets[0].transform;
        ropeGrowDirection.LookAt(sockets[1].transform);


        //first segment - join with socket
        GameObject prevSegment = Instantiate(ropeSegmentPrefab, sockets[0].transform.position, Quaternion.identity, rope.transform.GetChild(1));
        prevSegment.GetComponent<SpringJoint>().connectedBody = sockets[0].transform.parent.GetComponent<Rigidbody>();

        
        //middle segments - join with previous rope segment
        for(int i=0; i<segmentNumber-2; i++)
        {
            //middle segments
            GameObject newSegment = Instantiate(ropeSegmentPrefab, 
                prevSegment.transform.position + ropeGrowDirection.forward * segmentDistance, 
                Quaternion.identity, rope.transform.GetChild(1));
            newSegment.GetComponent<SpringJoint>().connectedBody = prevSegment.GetComponent<Rigidbody>();
            prevSegment = newSegment;
        }

        //last segment
        GameObject lastSegment = Instantiate(ropeSegmentPrefab, 
            prevSegment.transform.position + ropeGrowDirection.forward * segmentDistance, 
            Quaternion.identity, rope.transform.GetChild(1));
        lastSegment.GetComponent<SpringJoint>().connectedBody = prevSegment.GetComponent<Rigidbody>();
        lastSegment.transform.position = sockets[1].transform.position;

        

    }
}
