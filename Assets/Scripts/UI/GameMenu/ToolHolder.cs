using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolHolder : MonoBehaviour
{
    [SerializeField] int toolIndex;
    [SerializeField] GameObject toolPrefab;
    [SerializeField] GameObject gameMenu;

    private void Start()
    {
        if (System.Array.Exists(ProfileManager.activeProfile.unlockedTools, element => element == toolIndex))
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void InstatiateTool()
    {
        Instantiate(toolPrefab, gameMenu.transform.position, gameMenu.transform.rotation);
        Destroy(gameMenu);
    }
}
