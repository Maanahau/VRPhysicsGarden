using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravEnergyFormulaSheet
{
    public class GravEnergyFormula : BaseFormula
    {
        private ValueReader massReader;
        private ValueReader heightReader;

        protected override void Awake()
        {
            base.Awake();
            SetupSockets();
        }

        protected override void Update()
        {
            if (heightReader.isReading && massReader.isReading)
                computeButton.interactable = true;
            else
                computeButton.interactable = false;
        }


        public override void Compute()
        {
            float outputValue = massReader.averageValue * heightReader.averageValue * 9.8f;
            outputValue = (float) System.Math.Round(outputValue, 2);
            GameObject datacard = Instantiate(valueDatacardPrefab, outputSocket.transform.position, outputSocket.transform.rotation);
            datacard.GetComponent<ValueHolder>().SetData("Energy", outputValue, "J");
        }

        public override void SetupSockets()
        {
            heightReader = refProvider.valueSocket2.transform.GetChild(0).GetComponent<ValueReader>();
            massReader = refProvider.valueSocket1.transform.GetChild(0).GetComponent<ValueReader>();

            heightReader.requestedLabel = "Length";
            massReader.requestedLabel = "Mass";

            refProvider.valueSocket1.SetActive(true);
            refProvider.valueSocket2.SetActive(true);

            heightReader.ResetValue();
            massReader.ResetValue();
        }

    }
}

