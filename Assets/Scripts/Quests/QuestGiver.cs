using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] Quest[] giveableQuests;
    [SerializeField] UnityEvent onAllQuestCompleted;

    [SerializeField] GameObject questMarker;
    [SerializeField] Material availableQuestMaterial;
    [SerializeField] Material unavailableQuestMaterial;

    public static bool lockedSteps { get; set; }

    private void Awake()
    {
        StartCoroutine(SetupMarker());
    }

    public void StartNextQuest()
    {
        if (isQuestActive || lockedSteps)
            return;

        for (int i = 0; i < giveableQuests.Length; i++)
        {
            if (giveableQuests[i].CheckCompletion() == false)
            {
                foreach (int requiredQuestID in giveableQuests[i].requiredQuests)
                {
                    if (System.Array.Exists(ProfileManager.activeProfile.completedQuests, id => requiredQuestID == id) == false)
                    {
                        giveableQuests[i].onInsufficientRequirements.Invoke();
                        return;
                    }
                }
                giveableQuests[i].ActivateQuest();
                questMarker.SetActive(false);
                return;
            }
        }
        onAllQuestCompleted.Invoke();
    }

    public static bool isQuestActive = false;
    public static Quest currentActiveQuest;

    public static void NextStep()
    {
        if (currentActiveQuest && !lockedSteps)
            currentActiveQuest.NextStep();
    }

    public static void CompleteQuest()
    {
        if (currentActiveQuest)
        {
            currentActiveQuest.CompleteQuest();
        }
    }

    private IEnumerator SetupMarker()
    {
        while (true)
        {
            if (isQuestActive && questMarker.activeSelf)
            {
                questMarker.SetActive(false);
            }
            else
            {
                if (!isQuestActive && !questMarker.activeSelf && giveableQuests[giveableQuests.Length - 1].CheckCompletion() == false)
                {
                    questMarker.SetActive(true);

                    //material choice
                    bool materialChanged = false;
                    foreach (Quest quest in giveableQuests)
                    {
                        //check for quest requirements
                        if (quest.CheckCompletion() == false)
                        {
                            foreach (int requiredQuestID in quest.requiredQuests)
                            {
                                if (ProfileManager.activeProfile.completedQuests != null && 
                                    System.Array.Exists(ProfileManager.activeProfile.completedQuests, id => requiredQuestID == id) == false)
                                {
                                    questMarker.transform.GetChild(0).GetComponent<MeshRenderer>().material = unavailableQuestMaterial;
                                    materialChanged = true;
                                    break;
                                }
                            }
                            if (materialChanged)
                                break;
                            else
                            {
                                questMarker.transform.GetChild(0).GetComponent<MeshRenderer>().material = availableQuestMaterial;
                                break;
                            }
                        }
                    }
                }
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
