using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestAnswers
{
    public class CubeMassGen : QuestAnswer
    {
        private void Awake()
        {
            float mass = Random.Range(1f, 50f);
            GetComponent<Rigidbody>().mass = mass;
            correctValue = (float) System.Math.Round(mass, 2);
            label = "Mass";
        }
    }
}

