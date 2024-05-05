using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class CouplingAreaExist : Node
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (animalAI.CouplingAreas == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to copulate!");
                state = false;

            }
            else
            {
                // Debug.Log(animalAI.aiCategory + " has an area to copulate");
                state = true;
            } 
            return state;            
        }
    }
}