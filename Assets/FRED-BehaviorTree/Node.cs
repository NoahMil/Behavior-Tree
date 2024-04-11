using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    [Serializable]
    public abstract class Node
    {
        public List<Node> Children = new List<Node>();

        public abstract bool Execute(YvanAI yvanAI);
    }
}