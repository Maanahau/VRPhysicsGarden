using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatacardHolder : MonoBehaviour
{
    [SerializeField] int DatacardIndex;
    [SerializeField] GameObject DatacardPrefab;
    [SerializeField] GameObject gameMenu;

    private void Start()
    {
        if (System.Array.Exists(ProfileManager.activeProfile.unlockedDatacards, element => element == DatacardIndex))
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void InstatiateDatacard()
    {
        Instantiate(DatacardPrefab, gameMenu.transform.position, gameMenu.transform.rotation);
        Destroy(gameMenu);
    }
}
