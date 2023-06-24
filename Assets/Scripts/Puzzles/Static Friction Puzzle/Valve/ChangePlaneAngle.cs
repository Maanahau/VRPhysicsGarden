using UnityEngine;

public class ChangePlaneAngle : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] float rotationSpeed;

    private Rigidbody valveRigidbody;

    private void Awake()
    {
        valveRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //using deltaAngle cause rotations are in the [0, 360] interval
        float deltaAngle = Mathf.DeltaAngle(plane.transform.eulerAngles.x, 0);
        if (deltaAngle > -45.1f && deltaAngle < 45.1f)
        {
            plane.transform.Rotate(Vector3.right, valveRigidbody.angularVelocity.x * rotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            Debug.Log(deltaAngle);
            //limit rotation to 45, -45 degrees
            Vector3 correction = plane.transform.eulerAngles;
            if (deltaAngle < 0)
                correction.x = 45f;
            else
                correction.x = -45f;
            plane.transform.eulerAngles = correction;
        }
        

    }
}
