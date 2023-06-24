using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MassValueDatacardMaker : BaseDatacardMaker
{

    new public void Create()
    {
        base.Create();

        float mass = GetComponent<WeightSensorController>().measuredMass;
        if(mass > 0)
        {
            GameObject datacard = Instantiate(datacardPrefab, datacardSocket.transform.position, datacardSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Mass", mass, "Kg");
        }
    }
}
