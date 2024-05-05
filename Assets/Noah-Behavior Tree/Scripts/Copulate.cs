using System;
using UnityEngine;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using Object = UnityEngine.Object;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class Copulate : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            if (animalAI.NearestCouplingArea)
            {
                // Debug.Log(animalAI.aiCategory + " copulates");
                animalAI.CustomDestroy(animalAI.NearestCouplingArea);
                animalAI.MakeBabies(animalAI.aiCategory);
                animalAI.IsInLove = false;
                AnimalAI.UpdateCouplingAreas(animalAI.CouplingAreas, animalAI.aiCategory);
            }
            return false;
        }
    }
}