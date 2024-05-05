using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class IsHungry : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.IsHungry)
            {
                // Debug.Log(animalAI.aiCategory + " is hungry");
                state = true;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " is fed");
                state = false;
            }
            return state;            
        }
    }
}