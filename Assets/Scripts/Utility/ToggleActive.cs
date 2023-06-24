using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleActive : MonoBehaviour
{
    [SerializeField] UnityEvent onSetActive;
    [SerializeField] UnityEvent onSetInactive;

    public void OnPress(GameObject target)
    {
        if (target.activeInHierarchy)
        {
            onSetInactive.Invoke();
            target.SetActive(false);
        }
        else
        {
            onSetActive.Invoke();
            target.SetActive(true);
        }
    }
}
