using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VendingMachine : MonoBehaviour
{
    private bool cookieGiven;
    [SerializeField] GameObject cookiePrefab;
    [SerializeField] Transform origin;
    [SerializeField] UnityEvent onFirstCookieGiven;

    private void Awake()
    {
        cookieGiven = false;
    }

    public void CheckCookieState()
    {
        if (!cookieGiven)
        {
            cookieGiven = true;
            onFirstCookieGiven.Invoke();
        }
        else
        {
            GiveCookie();
        }
    }

    public void GiveCookie()
    {
        GameObject newCookie = Instantiate(cookiePrefab, origin.position, origin.rotation);
        newCookie.GetComponent<Rigidbody>().AddForce(origin.forward * 4, ForceMode.Impulse);
    }
}
