using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestWeAllLiftTogether
{
    public class AnswerCubeSetter : MonoBehaviour
    {
        [SerializeField] QuestGivenValue weightForceHolder;

        private void Awake()
        {
            //cube must be moved to this height to win
            float targetHeight = (float) System.Math.Round(Random.Range(3f, 6f), 2);
            float mass = (float) System.Math.Round(Random.Range(1f, 20f), 2);

            GetComponent<Rigidbody>().mass = mass;

            //given values: target height and weight force on cube
            GetComponent<QuestGivenValue>().value = targetHeight;
            weightForceHolder.value = (float) System.Math.Round(mass * 9.8f, 2);

            QuestAnswer answer = GetComponent<QuestAnswer>();
            answer.correctValue = mass * targetHeight * 9.8f;
            answer.label = "Energy";
        }
    }
}

