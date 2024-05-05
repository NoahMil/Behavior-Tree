using System;
using UnityEngine;
using Noah_Behavior_Tree.Scripts.BehaviorTree;
using Object = UnityEngine.Object;

namespace Noah_Behavior_Tree.Scripts
{
    [Serializable]
    public class Feed : Leaf
    {
        public override bool Execute(AnimalAI animalAI)
        {
            if (animalAI.NearestFeedingArea)
            {
                // Debug.Log(animalAI.aiCategory + "  eats food");
                animalAI.CustomDestroy(animalAI.NearestFeedingArea);
                animalAI.IsHungry = false;
                AnimalAI.UpdateFeedingAreas(animalAI.FeedingAreas, animalAI.aiCategory);
            }
            return false;
        }
        
    }

}