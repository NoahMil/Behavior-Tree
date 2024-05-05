using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class DrinkingAreaExist : Node
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.DrinkingAreas == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to drink!");
                state = false;
            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " has an area to drink");
                state = true;
            } 
            return state;            
        }
    }
}