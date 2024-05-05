using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class MoveToDrinkingArea : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state = false;
            if (animalAI.NearestDrinkingArea == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to drink!");
                animalAI.NearestDrinkingArea = animalAI.NearestDrinkingArea;
            }
            
            if (Vector3.Distance(animalAI.transform.position, animalAI.NearestDrinkingArea.transform.position) <= 1.0f)
            {
                animalAI.anim.SetInteger("Walk", 0);
                // Debug.Log(animalAI.aiCategory + " has reached its destination");
                state = true;
            }
            else
            {
                animalAI.anim.SetInteger("Walk", 1);
                animalAI.NavMeshAgent.SetDestination(animalAI.NearestDrinkingArea.transform.position);
                // Debug.Log(animalAI.aiCategory + " is going to its drinking area");
            }
            return state;
        }
    }
    
}