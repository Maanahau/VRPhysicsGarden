using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestGivenData
{
    public class MoreCubesMoreDataSetter : QuestGivenValue
    {
        private void Awake()
        {
            float mass = (float) System.Math.Round(Random.Range(1f, 3f), 2);
            float side = (float) System.Math.Round(Random.Range(0.6f, 0.8f), 2);

            transform.localScale = new Vector3(side, side, side);
            GetComponent<Rigidbody>().mass = mass;

            //value stored inside datacard
            value = side;

            //set quest answer (density)
            QuestAnswer answer = GetComponent<QuestAnswer>();
            answer.correctValue = mass / (side * side * side);
            answer.label = "Density";
        }
    }
}

