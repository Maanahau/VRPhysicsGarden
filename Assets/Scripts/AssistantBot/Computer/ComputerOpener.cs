using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ComputerOpener : MonoBehaviour
{
    [SerializeField] XRSocketInteractor formulaSocket;
    [SerializeField] XRSocketInteractor outputSocket;
    [SerializeField] AudioClip wrongAnswer;

    public void OnPress()
    {
        if (gameObject.activeInHierarchy)
        {
            if(formulaSocket.interactablesSelected.Count == 0 && outputSocket.interactablesSelected.Count == 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(wrongAnswer);
            }
        } 
        else
        {
            gameObject.SetActive(true);
        }
    }
}
