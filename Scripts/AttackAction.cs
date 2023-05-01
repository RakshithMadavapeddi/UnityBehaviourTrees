using UnityEngine;

public class AttackAction : BTNode
{
    private NPC npc;
    private Transform player;
    private PlayerHealth playerHealth;
    private float attackCooldown;
    private float currentCooldown;

    public AttackAction(NPC npc, Transform player, PlayerHealth playerHealth, float attackCooldown)
    {
        this.npc = npc;
        this.player = player;
        this.playerHealth = playerHealth;
        this.attackCooldown = attackCooldown;
        currentCooldown = attackCooldown;
    }

    public override NodeState Evaluate()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0)
        {
            playerHealth.TakeDamage(npc.attackDamage);
            currentCooldown = attackCooldown;
        }

        return NodeState.RUNNING;
    }
}
