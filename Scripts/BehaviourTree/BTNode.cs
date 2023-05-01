using UnityEngine;

public abstract class BTNode
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    protected NodeState currentState;

    public BTNode() { }

    public abstract NodeState Evaluate();
}
