using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConceptHolder : MonoBehaviour
{
    [SerializeField] int conceptIndex;
    [SerializeField] GameObject scrollView;
    [SerializeField] GameObject conceptPrefab;

    private static GameObject conceptInstance;

    private void Start()
    {
        if (System.Array.Exists(ProfileManager.activeProfile.unlockedConcepts, element => element == conceptIndex))
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void ShowConcept()
    {
        if(conceptInstance != null)
        {
            Destroy(conceptInstance);
        }
        conceptInstance = Instantiate(conceptPrefab, scrollView.transform);
        scrollView.GetComponent<ScrollRect>().content = conceptInstance.GetComponent<RectTransform>();
    }
}
