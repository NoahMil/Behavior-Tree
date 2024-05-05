using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class IsThirsty : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.IsThirsty)
            {
                // Debug.Log(animalAI.aiCategory + " is thirsty");
                state = true;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " is hydrated");
                state = false;
            }
            return state;            
        }
    }
}