using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleActive : MonoBehaviour
{
 
    [SerializeField] UnityEvent onSetActive;
    [SerializeField] UnityEvent onSetInactive;

    public void OnPress(GameObject target)
    {
        if (target.activeInHierarchy)
        {
            target.SetActive(false);
            onSetInactive.Invoke();
        }
        else
        {
            target.SetActive(true);
            onSetActive.Invoke();
        }
    }
}
