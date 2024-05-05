using System;
using UnityEngine;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using Object = UnityEngine.Object;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class Drink : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            if (animalAI.NearestDrinkingArea)
            {
                // Debug.Log(animalAI.aiCategory + " drinks water");
                animalAI.CustomDestroy(animalAI.NearestDrinkingArea);
                animalAI.IsThirsty = false;
                AnimalAI.UpdateDrinkingAreas(animalAI.DrinkingAreas, animalAI.aiCategory);
            }
            return false;
        }
    }
}