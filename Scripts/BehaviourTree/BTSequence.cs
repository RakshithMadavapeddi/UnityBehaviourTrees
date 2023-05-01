using System.Collections.Generic;

public class BTSequence : BTNode
{
    private List<BTNode> nodes;

    public BTSequence(List<BTNode> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool anyChildRunning = false;

        foreach (BTNode node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.FAILURE:
                    currentState = NodeState.FAILURE;
                    return currentState;
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    currentState = NodeState.SUCCESS;
                    return currentState;
            }
        }
        currentState = anyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return currentState;
    }
}
