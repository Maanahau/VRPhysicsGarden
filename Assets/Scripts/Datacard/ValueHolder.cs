using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using TMPro;

public class ValueHolder : MonoBehaviour
{
    [SerializeField] LocalizeStringEvent localizedLabel;
    [SerializeField] TextMeshProUGUI valueBox;

    public string label; //name of localization entry
    public float value;
    public string unit;

    public void SetData(string newLabel, float newValue, string newUnit)
    {
        label = newLabel;
        value = newValue;
        unit = newUnit;
        localizedLabel.SetEntry(label);
        valueBox.text = value.ToString() + " " + unit;
    }
}
