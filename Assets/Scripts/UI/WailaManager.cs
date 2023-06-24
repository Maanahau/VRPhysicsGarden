using System.Text;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.Localization;

public class WailaManager : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] [Tooltip("Canvas position offset relative to hovered object")] float positionOffset;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera.transform);
    }

    public void CheckForNameHolder(HoverEnterEventArgs hoverArgs)
    {
        GameObject hoveredObject = hoverArgs.interactableObject.transform.gameObject;
        WailaNameHolder nameHolder = hoveredObject.GetComponent<WailaNameHolder>();

        if (nameHolder)
        {
            gameObject.transform.position = hoveredObject.transform.position + Vector3.up * positionOffset;
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = nameHolder.objectName.GetLocalizedString();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void DisableCanvas()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }
}
