using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConceptsData", menuName = "ScriptableObject/ConceptsData")]
public class ConceptsData : ScriptableObject
{
    [System.Serializable] public struct ConceptsDataEntry
    {
        public int conceptID;
    }
}
