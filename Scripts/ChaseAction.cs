using UnityEngine;

public class ChaseAction : BTNode
{
    private NPC npc;
    private Transform player;

    public ChaseAction(NPC npc, Transform player)
    {
        this.npc = npc;
        this.player = player;
    }

    public override NodeState Evaluate()
    {
        npc.MoveToTarget(player.position);
        return NodeState.RUNNING;
    }
}
