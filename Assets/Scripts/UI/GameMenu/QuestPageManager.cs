using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class QuestPageManager : MonoBehaviour
{
    [SerializeField] QuestData questDataRef;
    [SerializeField] TextMeshProUGUI nameBox;
    [SerializeField] TextMeshProUGUI descriptionBox;
    [SerializeField] GameObject descriptionBackground;

    [SerializeField] LocalizedString noQuestString;

    private void Awake()
    {
        if (QuestGiver.isQuestActive)
        {
            nameBox.text = questDataRef.entries[QuestGiver.currentActiveQuest.questID].questName.GetLocalizedString();
            descriptionBox.text = questDataRef.entries[QuestGiver.currentActiveQuest.questID].description.GetLocalizedString();
            descriptionBackground.SetActive(true);
        }
        else
        {
            nameBox.text = noQuestString.GetLocalizedString();
            descriptionBox.enabled = false;
            descriptionBackground.SetActive(false);
        }
    }
}
