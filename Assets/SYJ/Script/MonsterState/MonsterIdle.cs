using UnityEngine;

public class MonsterIdleState : MonsterBaseState
{
    Animator animator;

    public MonsterIdleState(MonsterState monsterST) : base(monsterST) { }

    public override void OnMonsterStateEnter()
    {
        animator = _monsterState.GetComponent<Animator>();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.SetTrigger("Idle");
    }

    public override void OnMonsterStateUpdate()
    {
        
    }
    public override void OnMonsterStateExit()
    {

    }
}
