using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeLayerOnGrab : MonoBehaviour
{
    [SerializeField] int targetLayer;
    private int defaultLayer = 8; //Grabbable
    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        //if grabbedObject is a tool, change layer
        GameObject grabbedObject = args.interactableObject.transform.gameObject;
        grabbedObject.layer = targetLayer;
        if (grabbedObject.CompareTag("Tool"))
        {
            //change layer to superficial objects
            for (int i = 0; i < grabbedObject.transform.childCount; i++)
            {
                if (grabbedObject.transform.GetChild(i).gameObject.tag == "Button")
                    continue;
                grabbedObject.transform.GetChild(i).gameObject.layer = targetLayer;
            }
            //change layer to every model mesh
            GameObject model = grabbedObject.transform.GetChild(0).gameObject;
            model.layer = targetLayer;
            for(int i = 0; i < model.transform.childCount; i++)
            {
                model.transform.GetChild(i).gameObject.layer = targetLayer;
            }
        }
    }

    public void OnSelectExit(SelectExitEventArgs args)
    {
        GameObject grabbedObject = args.interactableObject.transform.gameObject;
        grabbedObject.layer = defaultLayer;
        if (grabbedObject.CompareTag("Tool"))
        {
            //change layer to superficial objects
            for (int i = 0; i < grabbedObject.transform.childCount; i++)
            {
                if (grabbedObject.transform.GetChild(i).gameObject.tag == "Button")
                    continue;
                grabbedObject.transform.GetChild(i).gameObject.layer = defaultLayer;
            }
            //change layer to every model mesh
            GameObject model = grabbedObject.transform.GetChild(0).gameObject;
            model.layer = targetLayer;
            for(int i = 0; i < model.transform.childCount; i++)
            {
                model.transform.GetChild(i).gameObject.layer = defaultLayer;
            }
        }
    }
}
