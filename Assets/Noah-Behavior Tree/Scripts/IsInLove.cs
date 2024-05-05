using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class IsInLove : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.IsInLove)
            {
                // Debug.Log(animalAI.aiCategory + " is in love");
                state = true;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " is single");
                state = false;
            }
            return state;            
        }
    }
}