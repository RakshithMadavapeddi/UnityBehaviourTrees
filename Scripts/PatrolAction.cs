using UnityEngine;
using System.Collections.Generic;

public class PatrolAction : BTNode
{
    private NPC npc;
    private List<Vector3> patrolPoints;
    private int currentPatrolIndex;

    public PatrolAction(NPC npc, Vector3[] patrolPoints)
    {
        this.npc = npc;
        this.patrolPoints = new List<Vector3>(patrolPoints);
        currentPatrolIndex = 0;
    }

    public override NodeState Evaluate()
    {
        if (patrolPoints.Count == 0) return NodeState.FAILURE;

        npc.MoveToTarget(patrolPoints[currentPatrolIndex]);

        if (Vector3.Distance(npc.transform.position, patrolPoints[currentPatrolIndex]) <= 0.5f)
        {
            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Count)
            {
                currentPatrolIndex = 0;
            }
        }

        return NodeState.RUNNING;
    }
}
