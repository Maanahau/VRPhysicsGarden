using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticFrictionFormula1 : MonoBehaviour
{
    [SerializeField] Button computeButton;
    [SerializeField] GameObject datacardPrefab;

    private ReferenceProvider refProvider;
    private ValueReader angleReader;
    private GameObject outputSocket;

    public void Start()
    {
        refProvider = transform.parent.parent.parent.GetComponent<ReferenceProvider>();
        angleReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
        outputSocket = refProvider.outputSocket;

        //request Angle on socket1
        angleReader.requestedLabel = "Angle";
        refProvider.valueSocket1.SetActive(true);
    }

    private void Update()
    {
        if (angleReader.isReading)
            computeButton.interactable = true;
        else
            computeButton.interactable = false;
    }

    public void Compute()
    {
        float outputValue = (float) System.Math.Round(System.Math.Tan(angleReader.averageValue), 2);
        GameObject datacard = Instantiate(datacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
        datacard.GetComponent<ValueHolder>().SetData("StaticFrictionCoefficient", outputValue, "");
    }
}
