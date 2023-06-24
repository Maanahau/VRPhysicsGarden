using UnityEngine;
using TMPro;

public class MeasureAngle : MonoBehaviour
{

    [SerializeField] float lineLength;
    [SerializeField] GameObject measureBias;
    [SerializeField] GameObject movingLine;
    [SerializeField] GameObject angleText;

    [HideInInspector] public float measuredAngle = 0;

    private float startingZAngle;   //use this as reference for angle measurement

    private LineRenderer movingLineRenderer;
    private TextMeshProUGUI textComponent;

    private Vector3 movingLinePos;
    private Vector3 movingLineRot;

    private void Awake()
    {
        textComponent = angleText.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //update movingLine rotation on the Z axis
        movingLineRot = movingLine.transform.eulerAngles;
        Vector3 newRotation = new Vector3(0, movingLineRot.y, movingLineRot.z);
        movingLine.transform.eulerAngles = newRotation;

        //update measuring line
        Vector3[] movingLinePoints = new Vector3[2];
        movingLinePoints[0] = movingLinePos + movingLine.transform.right * lineLength;
        movingLinePoints[1] = movingLinePos - movingLine.transform.right * lineLength;
        movingLineRenderer.SetPositions(movingLinePoints);

        //find angle
        measuredAngle = (float) System.Math.Round(Mathf.Abs(Mathf.DeltaAngle(startingZAngle, movingLineRot.z)), 1);
        textComponent.text = measuredAngle.ToString() + "°";
    }

    public void StartMeasuring()
    {
        //lock measureBias and movingLine on the horizon line
        Vector3 biasLockedRotation = new Vector3(0, measureBias.transform.eulerAngles.y, 0);
        measureBias.transform.eulerAngles = biasLockedRotation;
        movingLine.transform.eulerAngles = biasLockedRotation;

        //movingLine updated position and rotation
        movingLinePos = movingLine.transform.position;
        movingLineRot = movingLine.transform.eulerAngles;

        startingZAngle = measureBias.transform.eulerAngles.z; //starting angle for measurement

        //prepare points for bias line rendering
        Vector3[] biasLinePoints = new Vector3[2];
        biasLinePoints[0] = measureBias.transform.position + measureBias.transform.right * lineLength;
        biasLinePoints[1] = measureBias.transform.position - measureBias.transform.right * lineLength;
        measureBias.GetComponent<LineRenderer>().SetPositions(biasLinePoints);
        measureBias.GetComponent<LineRenderer>().enabled = true;

        //can safely use the same points for movingLine initialization
        movingLineRenderer = movingLine.GetComponent<LineRenderer>();
        movingLineRenderer.SetPositions(biasLinePoints);
        movingLineRenderer.enabled = true;
        this.enabled = true;
    }

    public void StopMeasuring()
    {
        movingLine.transform.rotation = measureBias.transform.rotation;
        measureBias.GetComponent<LineRenderer>().enabled = false;
        movingLineRenderer.enabled = false;
        this.enabled = false;
    }
}
