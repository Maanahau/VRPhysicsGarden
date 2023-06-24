using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceFormulaSheet
{
    public class AccelerationFormula : BaseFormula
    {
        private ValueReader forceReader;
        private ValueReader massReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (massReader.isReading && forceReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = forceReader.averageValue / massReader.averageValue;
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Acceleration", outputValue, "m/s²");
        }
        public override void SetupSockets()
        {
            massReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
            forceReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();

            massReader.requestedLabel = "Mass";
            forceReader.requestedLabel = "Force";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            massReader.ResetValue();
            forceReader.ResetValue();
        }

    }
}

