using UnityEngine;

public class MonsterHitState : MonsterBaseState
{
    Animator animator;
    public MonsterHitState(MonsterState monsterST) : base(monsterST) { }

    public override void OnMonsterStateEnter()
    {
        animator = _monsterState.GetComponent<Animator>();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            animator.SetTrigger("Hit");
    }
    public override void OnMonsterStateUpdate()
    {

    }
    public override void OnMonsterStateExit()
    {

    }
}