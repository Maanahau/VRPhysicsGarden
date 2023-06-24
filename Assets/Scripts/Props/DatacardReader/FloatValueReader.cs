using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System.Linq;

namespace DatacardReader
{
    public class FloatValueReader : MonoBehaviour
    {
        [SerializeField] XRSocketInteractor socket;
        [SerializeField] QuestAnswer answer;
        [SerializeField] float correctAnswerThreshold;

        [SerializeField] UnityEvent onCorrectValue;
        [SerializeField] UnityEvent onWrongValue;


        public void CheckValue()
        {
            if (socket.hasSelection)
            {
                GameObject datacard = socket.interactablesSelected.First().transform.gameObject;
                ValueHolder valueHolder = datacard.GetComponent<ValueHolder>();
                if (System.Math.Abs(valueHolder.value - answer.correctValue) <= correctAnswerThreshold && valueHolder.label == answer.label) 
                {
                    onCorrectValue.Invoke();
                    StartCoroutine(WaitBeforeDestroying(datacard));
                }
                else
                {
                    onWrongValue.Invoke();
                }

                Debug.Log("correctValue: " + answer.correctValue + " datacard: " + valueHolder.value);
            }
        }

        private IEnumerator WaitBeforeDestroying(GameObject datacard)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            Destroy(datacard);
        }

    }
}
