using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BaseDatacardMaker : MonoBehaviour
{
    [SerializeField] protected GameObject datacardPrefab;
    [SerializeField] protected XRSocketInteractor datacardSocket;

    public virtual void Create()
    {
        if (datacardSocket.GetComponent<XRSocketInteractor>().interactablesSelected.Count > 0)
            return;
    }
}
