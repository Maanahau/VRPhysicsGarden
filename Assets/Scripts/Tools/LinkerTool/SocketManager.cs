using UnityEngine;

public class SocketManager : MonoBehaviour
{
    [SerializeField] private GameObject rayOrigin;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectMaterial;

    public bool mode; //true = rope, false = spring

    private LineRenderer lineRenderer;
    private GameObject lastHoveredSocket;
    private MeshRenderer lastHighlightedMesh;

    private GameObject[] selectedSocket; //selected sockets for linking
    private bool hittingSocket;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit, maxDistance)
            && hit.collider.gameObject.CompareTag("LinkSocket")
            && hit.collider.gameObject.GetComponent<LinkSocketProperties>().busy == false
            && (!selectedSocket[0] || (hit.transform.gameObject != selectedSocket[0]
            && !hit.transform.IsChildOf(selectedSocket[0].transform.parent))))
        {
            //update last hovered socket if not marked as selected
            hittingSocket = true;
            if (lastHoveredSocket != hit.collider.gameObject)
            {
                lastHoveredSocket = hit.collider.gameObject;

                //change highlighted socket
                if (lastHighlightedMesh)
                    lastHighlightedMesh.enabled = false;

                lastHighlightedMesh = lastHoveredSocket.GetComponent<MeshRenderer>();
                lastHighlightedMesh.material = highlightMaterial;
            }
            
            if (!lastHighlightedMesh.enabled)
                lastHighlightedMesh.enabled = true;

            //draw ray
            if (!lineRenderer.enabled)
                lineRenderer.enabled = true;

            Vector3[] positions = new Vector3[2];
            positions[0] = rayOrigin.transform.position;
            positions[1] = rayOrigin.transform.position + rayOrigin.transform.forward * hit.distance;
            lineRenderer.SetPositions(positions);
        }
        else
        {
            hittingSocket = false;

            if (lineRenderer.enabled)
                lineRenderer.enabled = false;

            if (lastHighlightedMesh)
                lastHighlightedMesh.enabled = false;
        }
    }

    public void OnSelectEnter()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        selectedSocket = new GameObject[2];
    }

    public void OnSelectExit()
    {
        lineRenderer.enabled = false;
        if (selectedSocket[0])
            selectedSocket[0].GetComponent<MeshRenderer>().enabled = false;

        if (lastHighlightedMesh)
        {
            lastHighlightedMesh.enabled = false;
            lastHighlightedMesh = null;
        }

        //unmark selected sockets
        selectedSocket = null;
        lastHoveredSocket = null;
    }

    public void MarkSocket()
    {
        if (hittingSocket)
        {
            if (!selectedSocket[0])
            {
                selectedSocket[0] = lastHoveredSocket;
                lastHighlightedMesh.material = selectMaterial;
                lastHighlightedMesh.enabled = true;

                //turn off highlighting on selected socket
                lastHighlightedMesh = null;
                lineRenderer.enabled = false;
            }
            else
            {
                if (!lastHoveredSocket.transform.IsChildOf(selectedSocket[0].transform.parent))
                {
                    selectedSocket[1] = lastHoveredSocket;
                }
            }
        }

        if(selectedSocket != null && selectedSocket[0] && selectedSocket[1])
        {
            //do stuff depending on the mode;
            if (mode)
            {
                gameObject.GetComponent<RopeMaker>().CreateRope(selectedSocket);
            }
            else
            {
                gameObject.GetComponent<SpringMaker>().CreateSpring(selectedSocket);
            }

            //clear socket info
            selectedSocket[0].GetComponent<MeshRenderer>().enabled = false;
            selectedSocket[1].GetComponent<MeshRenderer>().enabled = false;
            selectedSocket = new GameObject[2];
            lastHighlightedMesh = null;
            lastHoveredSocket = null;
        }
    }

}
