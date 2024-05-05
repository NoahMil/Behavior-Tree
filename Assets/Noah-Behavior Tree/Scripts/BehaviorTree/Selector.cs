using System;
using BehaviorTree;

namespace Noah_Behavior_Tree.Scripts.BehaviorTree
{
    [Serializable]
    public class Selector : Composite
    {
        public override bool Execute(AnimalAI animalAI)
        {
            foreach (Node child in Children)
            {
                if (child.Execute(animalAI)) return true;
            }
            return false;
        }
    }
}