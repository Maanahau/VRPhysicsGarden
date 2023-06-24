using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

namespace DatacardReader
{
    public class CannonReader : MonoBehaviour
    {
        [SerializeField] XRSocketInteractor socket;
        [SerializeField] FireCannon cannon;


        public void TransferValue()
        {
            if (socket.hasSelection)
            {
                GameObject datacard = socket.interactablesSelected.First().transform.gameObject;
                ValueHolder valueHolder = datacard.GetComponent<ValueHolder>();
                if (valueHolder.label == "Force") 
                {
                    cannon.newtonValue = valueHolder.value;
                    StartCoroutine(WaitBeforeDestroying(datacard));
                }
                Debug.Log("datacard: " + valueHolder.value);
            }
        }

        private IEnumerator WaitBeforeDestroying(GameObject datacard)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Destroy(datacard);
        }
    }
}

