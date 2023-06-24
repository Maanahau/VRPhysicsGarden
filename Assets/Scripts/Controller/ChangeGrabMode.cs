using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeGrabMode : MonoBehaviour
{

    private XRRayInteractor rayInteractor;
    //use toggle mode for tools and state mode for world objects like doors, valves etc...

    private void Start()
    {
        rayInteractor = gameObject.GetComponent<XRRayInteractor>();
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("WorldInteractable"))
        {
            rayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.State;
        }
        else
        {
            rayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Toggle;
        }
    }
}
