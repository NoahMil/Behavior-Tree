using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class FeedingAreaExist : Node
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.FeedingAreas == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to feed!");
                state = false;

            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " has an area to feed");
                state = true;
            } 
            return state;            
        }
    }
}