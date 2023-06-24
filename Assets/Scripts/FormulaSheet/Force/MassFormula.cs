using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceFormulaSheet
{
    public class MassFormula : BaseFormula
    {
        private ValueReader forceReader;
        private ValueReader accelerationReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (accelerationReader.isReading && forceReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = forceReader.averageValue / accelerationReader.averageValue;
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Mass", outputValue, "Kg");
        }
        public override void SetupSockets()
        {
            accelerationReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
            forceReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();

            accelerationReader.requestedLabel = "Acceleration";
            forceReader.requestedLabel = "Force";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            accelerationReader.ResetValue();
            forceReader.ResetValue();
        }

    }
}

