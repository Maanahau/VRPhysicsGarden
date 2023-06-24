using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DensityFormulaSheet
{
    public class MassCubeFormula : BaseFormula
    {
        private ValueReader densityReader;
        private ValueReader sideReader;

        override protected void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        override protected void Update()
        {
            if (densityReader.isReading && sideReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }

        override public void Compute()
        {
            float outputValue = densityReader.averageValue * (float) Math.Pow(sideReader.averageValue, 3);
            outputValue = (float)Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Mass", outputValue, "Kg");
        }

        public override void SetupSockets()
        {
            densityReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();
            sideReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();

            densityReader.requestedLabel = "Density";
            sideReader.requestedLabel = "Side";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            densityReader.ResetValue();
            sideReader.ResetValue();
        }

    }
}

