using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class SleepingAreaExist : Leaf
    {
        
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.SleepingArea == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to sleep!");
                state = false;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " has an area to sleep");
                state = true;
            }
            return state;            
        }
    }
}
