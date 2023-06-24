using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObject/QuestData")]
public class QuestData : ScriptableObject
{
    [System.Serializable] public struct QuestDataEntry
    {
        public LocalizedString questName;
        public LocalizedString description;
    }

    //index in this array = questID
    [SerializeField] public QuestDataEntry[] entries;
}
