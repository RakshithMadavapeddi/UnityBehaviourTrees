using System;

public class BTCondition : BTNode
{
    private Func<bool> condition;

    public BTCondition(Func<bool> condition)
    {
        this.condition = condition;
    }

    public override NodeState Evaluate()
    {
        if (condition())
        {
            currentState = NodeState.SUCCESS;
        }
        else
        {
            currentState = NodeState.FAILURE;
        }
        return currentState;
    }
}

