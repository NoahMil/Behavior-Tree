using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class NearestBedExist : Leaf
    {
        public override bool Execute(YvanAI yvanAI)
        {
            GameObject nearestBed = yvanAI.NearestBed;
            Debug.Log("is nearest bed exist ?");
            return nearestBed != null;
        }
    }
}