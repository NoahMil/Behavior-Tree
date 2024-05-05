using System;
using System.Collections.Generic;
using BehaviorTree;

namespace Noah_Behavior_Tree.Scripts.BehaviorTree
{
    [Serializable]
    public abstract class Node
    {
        public List<Node> Children = new List<Node>();

        public abstract bool Execute(AnimalAI animalAI);
    }
}