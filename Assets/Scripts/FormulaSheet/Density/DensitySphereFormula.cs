using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DensityFormulaSheet
{
    public class DensitySphereFormula : BaseFormula
    {
        private ValueReader massReader;
        private ValueReader radiusReader;

        override protected void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        override protected void Update()
        {
            if (massReader.isReading && radiusReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = 3f/4f * massReader.averageValue / (3.14f * (float) Math.Pow(radiusReader.averageValue, 3));
            outputValue = (float)Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Density", outputValue, "Kg/m³");
        }

        public override void SetupSockets()
        {
            massReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
            radiusReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();

            massReader.requestedLabel = "Mass";
            radiusReader.requestedLabel = "Radius";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            massReader.ResetValue();
            radiusReader.ResetValue();
        }
    }
}

