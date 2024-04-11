using System;

namespace BehaviorTree
{
    [Serializable]
    public class Sequence : Composite
    {
        public override bool Execute(YvanAI yvanAI)
        {
            foreach (Node child in Children)
            {
                if (!child.Execute(yvanAI)) return false;
            }
            return true;
        }
    }
}