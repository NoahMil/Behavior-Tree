using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class MoveToCouplingArea : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state = false;
            if (animalAI.NearestCouplingArea == null)
            {
                // Debug.Log(animalAI.aiCategory + " has nowhere to copulate!");
                animalAI.NearestCouplingArea = animalAI.NearestCouplingArea;
            }
            
            if (Vector3.Distance(animalAI.transform.position, animalAI.NearestCouplingArea.transform.position) <= 1.0f)
            {
                animalAI.anim.SetInteger("Walk", 0);
                // Debug.Log(animalAI.aiCategory + " has reached its destination");
                state = true;
            }
            else
            {
                animalAI.anim.SetInteger("Walk", 1);
                animalAI.NavMeshAgent.SetDestination(animalAI.NearestCouplingArea.transform.position);
                // Debug.Log(animalAI.aiCategory + " is going to its coupling area");
            }
            return state;
        }
    }
    
}