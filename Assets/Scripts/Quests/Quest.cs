using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    public int questID;

    public int[] requiredQuests = null;

    [System.Serializable] public struct QuestStep
    {
        public UnityEvent onStep;
    }
    [SerializeField] QuestStep[] steps;
    public UnityEvent onInsufficientRequirements;

    private int stepIndex;

    public void NextStep()
    {
        if (stepIndex < steps.Length)
            steps[stepIndex++].onStep.Invoke();
        else
            return;
    }

    public void NextStepAfterSeconds(float seconds)
    {
        StartCoroutine(StepWaiter(seconds));
    }

    private IEnumerator StepWaiter(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        NextStep();
    }

    public void ActivateQuest()
    {
        if (!QuestGiver.isQuestActive)
        {
            //check completed quests
            if(requiredQuests != null)
            {
                foreach(int requiredID in requiredQuests)
                {
                    if (!System.Array.Exists(ProfileManager.activeProfile.completedQuests, element => element == requiredID))
                    {
                        onInsufficientRequirements.Invoke();
                        return;
                    }
                }
            }

            QuestGiver.isQuestActive = true;
            QuestGiver.currentActiveQuest = this;
            stepIndex = 0;
            NextStep();
        }
    }

    public void CompleteQuest()
    {
        if(QuestGiver.isQuestActive && QuestGiver.currentActiveQuest == this)
        {
            ProfileManager.AddCompletedQuest(questID);
            QuestGiver.isQuestActive = false;
        }
    }

    public bool CheckCompletion()
    {
        if(ProfileManager.activeProfile.completedQuests != null)
            foreach(int id in ProfileManager.activeProfile.completedQuests)
            {
                if (questID == id)
                    return true;
            }
            return false;
    }

    public void UnlockTool(int id)
    {
        ProfileManager.AddUnlockedTool(id);
    }

    public void UnlockConcept(int id)
    {
        ProfileManager.AddUnlockedConcept(id);
    }

    public void UnlockMap(int id)
    {
        ProfileManager.AddUnlockedMap(id);
    }

    public void UnlockDatacard(int id)
    {
        ProfileManager.AddUnlockedDatacard(id);
    }
}
