using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    private Animator animator;

    private static readonly int Patrol = Animator.StringToHash("Patrol");
    private static readonly int Chase = Animator.StringToHash("Chase");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimatorParameters(NPC.NPCState currentState, bool canSeePlayer, bool isCloseEnoughToAttack)
    {
        animator.SetBool(Patrol, currentState == NPC.NPCState.Patrol);
        animator.SetBool(Chase, canSeePlayer && !isCloseEnoughToAttack);
        animator.SetBool(Attack, canSeePlayer && isCloseEnoughToAttack);
    }
}
