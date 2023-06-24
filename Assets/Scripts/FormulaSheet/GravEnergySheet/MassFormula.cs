using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GravEnergyFormulaSheet
{
    public class MassFormula : BaseFormula
    {
        private ValueReader energyReader;
        private ValueReader heightReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (heightReader.isReading && energyReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }


        public override void Compute()
        {
            float outputValue = energyReader.averageValue / (heightReader.averageValue * 9.8f);
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Mass", outputValue, "Kg");
        }

        public override void SetupSockets()
        {
            heightReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();
            energyReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();

            heightReader.requestedLabel = "Length";
            energyReader.requestedLabel = "Energy";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            heightReader.ResetValue();
            energyReader.ResetValue();
        }

    }
}

