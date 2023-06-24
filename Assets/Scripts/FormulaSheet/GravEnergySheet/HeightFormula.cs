using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GravEnergyFormulaSheet
{
    public class HeightFormula : BaseFormula
    {
        private ValueReader massReader;
        private ValueReader energyReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (energyReader.isReading && massReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }


        public override void Compute()
        {
            float outputValue = energyReader.averageValue / (massReader.averageValue * 9.8f);
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Energy", outputValue, "J");
        }

        public override void SetupSockets()
        {
            energyReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();
            massReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();

            energyReader.requestedLabel = "Energy";
            massReader.requestedLabel = "Mass";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            energyReader.ResetValue();
            massReader.ResetValue();
        }

    }
}

