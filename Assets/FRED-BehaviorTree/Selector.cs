using System;

namespace BehaviorTree
{
    [Serializable]
    public class Selector : Composite
    {
        public override bool Execute(YvanAI yvanAI)
        {
            foreach (Node child in Children)
            {
                if (child.Execute(yvanAI)) return true;
            }
            return false;
        }
    }
}