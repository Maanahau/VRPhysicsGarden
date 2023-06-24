using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Localization;

public class AngleValueDatacardMaker : BaseDatacardMaker
{

    public override void Create()
    {
        base.Create();

        GameObject datacard = Instantiate(datacardPrefab, datacardSocket.transform.position, datacardSocket.transform.rotation);
        datacard.GetComponent<ValueHolder>().SetData("Angle", GetComponent<MeasureAngle>().measuredAngle, "°");
    }
}
