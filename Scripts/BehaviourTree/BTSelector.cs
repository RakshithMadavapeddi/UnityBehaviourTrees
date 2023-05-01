using System.Collections.Generic;

public class BTSelector : BTNode
{
    private List<BTNode> nodes;

    public BTSelector(List<BTNode> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (BTNode node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.SUCCESS:
                    currentState = NodeState.SUCCESS;
                    return currentState;
                case NodeState.RUNNING:
                    currentState = NodeState.RUNNING;
                    return currentState;
                default:
                    continue;
            }
        }
        currentState = NodeState.FAILURE;
        return currentState;
    }
}
