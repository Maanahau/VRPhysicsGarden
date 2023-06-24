using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ForceFormulaSheet
{
    public class ForceFormula : BaseFormula
    {
        private ValueReader massReader;
        private ValueReader accelerationReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (accelerationReader.isReading && massReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = massReader.averageValue * accelerationReader.averageValue;
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Force", outputValue, "N");
        }
        public override void SetupSockets()
        {
            accelerationReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();
            massReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();

            accelerationReader.requestedLabel = "Acceleration";
            massReader.requestedLabel = "Mass";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            accelerationReader.ResetValue();
            massReader.ResetValue();
        }

    }
}

