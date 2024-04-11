using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum NodeState
{
    RUNNING,
    SUCCESS,
    FAILURE,
}

public class Node : MonoBehaviour
{
    public Node parent;
    public List<Node> children = new List<Node>();

    public Node()
    {
        parent = null;
    }

    public Node(List<Node> children)
    {
        foreach (Node child in children)
        {
            Attach(child);
        }
    }

    private void Attach(Node node)
    {
        node.parent = this;
        children.Add(node);
    }
}
