using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueDatacardSpawner : MonoBehaviour
{
    [SerializeField] GameObject valueDatacardPrefab;
    [SerializeField] Transform socketTransform;
    [SerializeField] QuestGivenValue questGivenValue;
    [SerializeField] string label; //name of localization entry
    [SerializeField] string unit; //measurement unit of value

    private float value;

    public void SpawnValueDatacard()
    {
        GameObject datacard = Instantiate(valueDatacardPrefab, socketTransform.position, socketTransform.rotation);
        datacard.GetComponent<ValueHolder>().SetData(label, questGivenValue.value, unit);
    }
}
