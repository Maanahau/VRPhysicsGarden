using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class XRButton : MonoBehaviour
{
    private GameObject buttonBody;
    [SerializeField] float pressedButtonOffset;
    [SerializeField] LayerMask collisionLayerMask;

    [SerializeField] UnityEvent onPress;
    [SerializeField] UnityEvent onRelease;
    
    private bool isPressed;
    private GameObject pressingObject;
    private Vector3 pressTranslation;

    // Start is called before the first frame update
    void Start()
    {
        buttonBody = transform.GetChild(0).gameObject;
        pressTranslation = new Vector3(0, 0, -pressedButtonOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && ((1 << other.gameObject.layer) & collisionLayerMask) != 0)
        {
            isPressed = true;
            buttonBody.transform.Translate(pressTranslation);
            pressingObject = other.gameObject;
            onPress.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == pressingObject)
        {
            isPressed = false;
            buttonBody.transform.Translate(-pressTranslation);
            pressingObject = null;
            onRelease.Invoke();
            StartCoroutine(TriggerCooldown());
        }
    }

    private IEnumerator TriggerCooldown()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        GetComponent<BoxCollider>().enabled = true;
    }
}
