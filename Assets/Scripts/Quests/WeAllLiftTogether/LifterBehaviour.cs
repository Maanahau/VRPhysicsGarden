using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuestWeAllLiftTogether
{
    public class LifterBehaviour : MonoBehaviour
    {
        public float energyValue { get; set; }

        [SerializeField] GameObject plane;
        [SerializeField] GameObject content;
        [SerializeField] UnityEvent onCorrectAnswer;
        [SerializeField] UnityEvent onWrongAnswer;
        [SerializeField] UnityEvent onPositionReset;

        private Vector3 defaultPosition;
        private Vector3 targetPosition;
        private RopePositionUpdater ropeUpdater;
        private bool resettingPosition;

        //time variables for movement
        private float t;
        private float timeToReachTarget;

        private void Awake()
        {
            defaultPosition = plane.transform.position;
            ropeUpdater = GetComponent<RopePositionUpdater>();
            resettingPosition = false;
        }

        private void Update()
        {
            if (plane.transform.position == targetPosition)
            {
                this.enabled = false;

                if (!resettingPosition)
                {
                    if (System.Math.Abs(energyValue - content.GetComponent<QuestAnswer>().correctValue) <= 0.01)
                    {
                        onCorrectAnswer.Invoke();
                    }
                    else
                    {
                        ResetPosition();
                        onWrongAnswer.Invoke();
                    }
                }
                else
                {
                    resettingPosition = false;
                    onPositionReset.Invoke();
                }

                return;
            }

            t += Time.deltaTime / timeToReachTarget;
            plane.transform.position = Vector3.Lerp(plane.transform.position, targetPosition, 0.05f * t);

            ropeUpdater.UpdatePositions();
        }

        public void ResetPosition()
        {
            targetPosition = defaultPosition;
            resettingPosition = true;
            this.enabled = true;

            t = 0;
            timeToReachTarget = Vector3.Magnitude(plane.transform.position - defaultPosition) / 2f;
        }

        public void GetHeightAndMove()
        {
            float height = energyValue / (9.8f * content.GetComponent<Rigidbody>().mass);
            targetPosition = defaultPosition + new Vector3(0, height, 0);
            this.enabled = true;

            t = 0;
            timeToReachTarget = Vector3.Magnitude(plane.transform.position - targetPosition);
        }
    }
}
