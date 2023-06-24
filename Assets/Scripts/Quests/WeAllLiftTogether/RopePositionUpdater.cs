using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestWeAllLiftTogether
{
    public class RopePositionUpdater : MonoBehaviour
    {
        [SerializeField] LineRenderer lineRenderer;
        [SerializeField] Transform ropeOrigin;
        [SerializeField] Transform ropeEnd;

        private void Awake()
        {
            UpdatePositions();
        }
        public void UpdatePositions()
        {
            Vector3[] newPositions = { ropeOrigin.position, ropeEnd.position };
            lineRenderer.SetPositions(newPositions);
        }
    }
}


