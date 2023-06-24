using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAwakeEventTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake;

    private void Awake()
    {
        onAwake.Invoke();
    }
}
