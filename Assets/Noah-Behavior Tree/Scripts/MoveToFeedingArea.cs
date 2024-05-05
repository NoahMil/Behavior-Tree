using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class MoveToFeedingArea : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state = false;
            if (animalAI.NearestFeedingArea == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to drink!");
                animalAI.NearestFeedingArea = animalAI.NearestFeedingArea;
            }
            
            if (Vector3.Distance(animalAI.transform.position, animalAI.NearestFeedingArea.transform.position) <= 1.0f)
            {
                animalAI.anim.SetInteger("Walk", 0);
                // Debug.Log(animalAI.aiCategory + " has reached its destination");
                state = true;
            }
            else
            {
                animalAI.anim.SetInteger("Walk", 1);
                animalAI.NavMeshAgent.SetDestination(animalAI.NearestFeedingArea.transform.position);
                // Debug.Log(animalAI.aiCategory + " is going to its drinking area");
            }
            return state;
        }
    }
    
}