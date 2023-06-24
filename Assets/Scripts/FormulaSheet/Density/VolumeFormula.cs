using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DensityFormulaSheet
{
    public class VolumeFormula : BaseFormula
    {
        private ValueReader densityReader;
        private ValueReader massReader;

        override protected void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (densityReader.isReading && massReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = massReader.averageValue / densityReader.averageValue;
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Volume", outputValue, "m³");
        }

        public override void SetupSockets()
        {
            densityReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
            massReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();

            densityReader.requestedLabel = "Density";
            massReader.requestedLabel = "Mass";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            densityReader.ResetValue();
            massReader.ResetValue();
        }
    }
}

