using System;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using UnityEngine;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class Sleep : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            bool state;
            if (!animalAI.IsSleeping)
            {
                animalAI.IsSleeping = true;
                // Debug.Log(animalAI.aiCategory + "  is sleeping");
            }
            animalAI.SleepTime -= Time.deltaTime;
            if (animalAI.SleepTime <= 0f)
            {
                // Debug.Log(animalAI.aiCategory + " wakes up");
                animalAI.IsSleepy = false;
                animalAI.IsSleeping = false;
                state = false;
            }
            else
            {
                state = true;
            }
            return state;
        }
    }
}