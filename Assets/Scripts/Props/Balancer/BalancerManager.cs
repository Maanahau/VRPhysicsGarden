using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balancer
{
    public class BalancerManager : MonoBehaviour
    {
        [SerializeField] Transform platform1;
        [SerializeField] Transform platform2;
        [SerializeField] PlatformBehaviour behaviour1;
        [SerializeField] PlatformBehaviour behaviour2;

        //platforms can't move lower or higher than this value
        [SerializeField] float maxPlatformOffset;

        private float oldTotalMass;
        private float targetYPos;
        private Vector3 platform1BasePosition;
        private Vector3 platform2BasePosition;

        private void Awake()
        {
            platform1BasePosition = platform1.position;
            platform2BasePosition = platform2.position;
        }

        private void Update()
        {
            float deltaMass = behaviour1.GetTotalMass() - behaviour2.GetTotalMass();
            if (oldTotalMass != deltaMass)
            {
                oldTotalMass = deltaMass;

                if (System.Math.Abs(deltaMass) > maxPlatformOffset)
                    targetYPos = maxPlatformOffset * System.Math.Sign(deltaMass);
                else
                    targetYPos = deltaMass;

            }

            if (System.Math.Abs(platform1.position.y) != targetYPos)
            { 
                Vector3 translation = new Vector3(0, targetYPos, 0);
                platform1.position = Vector3.Lerp(platform1.position, platform1BasePosition - translation, 0.7f * Time.deltaTime);
                platform2.position = Vector3.Lerp(platform2.position, platform2BasePosition + translation, 0.7f * Time.deltaTime);
            }
        }
    }
}

