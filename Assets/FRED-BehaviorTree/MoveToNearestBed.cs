using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class MoveToNearestBed : Leaf
    {
        public override bool Execute(YvanAI yvanAI)
        {
            GameObject nearestBed = yvanAI.NearestBed;
            float speed = yvanAI.moveSpeed;
            if (nearestBed != null)
            {
                Vector3 yvanPosition = yvanAI.transform.position;
                Vector3 bedPosition = nearestBed.transform.position;
                float distance = Vector3.Distance(yvanPosition, bedPosition);
                float delta = distance / speed;
                Vector3 newPosition = Vector3.Lerp(yvanPosition, bedPosition, delta);
                yvanAI.transform.position = newPosition;
                Debug.Log("Yvan move to nearest bed");
            }
            return true;
        }
    }
}