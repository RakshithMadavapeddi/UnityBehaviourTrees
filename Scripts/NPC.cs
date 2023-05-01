using UnityEngine;
using System.Collections.Generic;
public class NPC : MonoBehaviour
{

    public enum NPCState { Patrol, Chase, Attack }
    public NPCState currentState;

    public Transform player;
    public PlayerHealth playerHealth;
    public Vector3[] patrolPoints;
    public float chaseDistance = 10f;
    public float attackDistance = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 1f;
    public float moveSpeed = 3f;
    public float viewAngle = 90f;
    public float viewRadius = 10f;

    private FieldOfView fieldOfView;
    private BTNode behaviorTree;
    private NPCAnimatorController npcAnimatorController;

    void Start()
    {
        fieldOfView = gameObject.AddComponent<FieldOfView>();
        fieldOfView.viewRadius = viewRadius;
        fieldOfView.viewAngle = viewAngle;
        fieldOfView.targetMask = LayerMask.GetMask("Player");
        fieldOfView.obstacleMask = LayerMask.GetMask("Obstacle");

        playerHealth = player.GetComponent<PlayerHealth>();

        PatrolAction patrolAction = new PatrolAction(this, patrolPoints);
        ChaseAction chaseAction = new ChaseAction(this, player);
        AttackAction attackAction = new AttackAction(this, player, playerHealth, attackCooldown);

        BTCondition canSeePlayer = new BTCondition(() => fieldOfView.CanSeeTarget(player));
        BTCondition isNearPlayer = new BTCondition(() => Vector3.Distance(transform.position, player.position) <= chaseDistance);
        BTCondition isCloseEnoughToAttack = new BTCondition(() => Vector3.Distance(transform.position, player.position) <= attackDistance);

        BTSequence chaseSequence = new BTSequence(new List<BTNode> { canSeePlayer, isNearPlayer, chaseAction });
        BTSequence attackSequence = new BTSequence(new List<BTNode> { canSeePlayer, isCloseEnoughToAttack, attackAction });
        BTSelector mainSelector = new BTSelector(new List<BTNode> { attackSequence, chaseSequence, patrolAction });

        behaviorTree = mainSelector;

        npcAnimatorController = GetComponent<NPCAnimatorController>();
    }

    void Update()
    {
        currentState = (NPCState)behaviorTree.Evaluate();
        bool canSeePlayer = fieldOfView.CanSeeTarget(player);
        bool isCloseEnoughToAttack = Vector3.Distance(transform.position, player.position) <= attackDistance;
        npcAnimatorController.UpdateAnimatorParameters(currentState, canSeePlayer, isCloseEnoughToAttack);
    }

    public void MoveToTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(target);
    }
}
