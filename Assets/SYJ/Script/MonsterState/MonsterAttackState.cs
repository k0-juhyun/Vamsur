using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    Animator animator;
    public MonsterAttackState(MonsterState monsterST) : base(monsterST) { }

    public override void OnMonsterStateEnter()
    {
        Debug.Log("Attack");

        animator = _monsterState.GetComponent<Animator>();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            animator.SetTrigger("Attack");
    }
    public override void OnMonsterStateUpdate()
    {

    }
    public override void OnMonsterStateExit()
    {

    }
}
