using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class IsSleepy : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.IsSleepy)
            {
                // Debug.Log(animalAI.aiCategory + "  sleepy");
                state = true;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " is wide awake");
                state = false;
            }
            return state;            
        }
    }
}