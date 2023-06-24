using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestGivenData
{
    public class TheUntouchableSetter : QuestGivenValue
    {
        private void Awake()
        {
            float density;
            float mass = Random.Range(1f, 5f);
            float cubeSide = Random.Range(0.3f, 0.5f);
            float volume = cubeSide * cubeSide * cubeSide;

            gameObject.transform.localScale = new Vector3(cubeSide, cubeSide, cubeSide);
            GetComponent<Rigidbody>().mass = mass;
            density = mass / volume;

            //value stored inside datacard
            value = density;

            //set quest answer (cubeSide)
            QuestAnswer answer = GetComponent<QuestAnswer>();
            answer.correctValue = volume;
            answer.label = "Volume";

            Debug.Log("density:" + density + " mass:" + mass + " volume:" + volume);
        }
    }
}

