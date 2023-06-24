using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System.Linq;

public class ValueReader : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textBox;

    public float averageValue;
    public bool isReading;
    public string requestedLabel;

    private List<float> values;

    private void Awake()
    {
        values = new List<float>();
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (requestedLabel == args.interactableObject.transform.gameObject.GetComponent<ValueHolder>().label)
        {
            isReading = true;
            values.Add(args.interactableObject.transform.gameObject.GetComponent<ValueHolder>().value);
            averageValue = values.Sum() / values.Count;
            textBox.text = averageValue.ToString();
            StartCoroutine(WaitBeforeDestroying(args.interactableObject.transform.gameObject));
        }
    }

    public void ResetValue()
    {
        isReading = false;
        values = new List<float>();
        textBox.text = "0";
    }

    private IEnumerator WaitBeforeDestroying(GameObject datacard)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(datacard);
    }
}
