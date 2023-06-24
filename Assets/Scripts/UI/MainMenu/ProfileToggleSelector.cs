using UnityEngine;
using TMPro;

public class ProfileToggleSelector : MonoBehaviour
{
    public static string selectedName;

    public void selectThisProfile()
    {
        selectedName = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
    }
}
