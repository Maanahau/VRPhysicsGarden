using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FormulaReader : MonoBehaviour
{
    [SerializeField] Transform canvas;

    private GameObject datacard;
    private GameObject instantiatedSheet;

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        datacard = args.interactableObject.transform.gameObject;
        instantiatedSheet = Instantiate(datacard.GetComponent<FormulaHolder>().sheetPrefab, canvas);
    }

    public void OnSelectExit()
    {
        Destroy(instantiatedSheet);
    }

}
