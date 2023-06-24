using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System.Linq;

namespace DatacardReader
{
    public class LifterReader : MonoBehaviour
    {
        [SerializeField] XRSocketInteractor socket;
        [SerializeField] QuestWeAllLiftTogether.LifterBehaviour lifter;

        [SerializeField] UnityEvent onSelection;

        private ValueHolder valueHolder;
        private GameObject datacard;

        public void CheckValue()
        {
            datacard = socket.interactablesSelected.First().transform.gameObject;
            valueHolder = datacard.GetComponent<ValueHolder>();
            if (socket.hasSelection)
            {
                if (valueHolder.label == "Energy") 
                {
                    StartCoroutine(WaitBeforeProcessing(datacard));
                }
            }
        }

        private IEnumerator WaitBeforeProcessing(GameObject datacard)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            lifter.energyValue = valueHolder.value;
            lifter.GetHeightAndMove();
            Destroy(datacard);
            onSelection.Invoke();
        }

    }
}
