using System;
using UnityEngine;

namespace BehaviorTree
{
    [Serializable]
    public class IsAlive : Leaf
    {
        public override bool Execute(YvanAI yvanAI)
        {
            Debug.Log("Yvan is alive ?");
            return yvanAI.IsAlive;
        }
    }
}