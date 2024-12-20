using UnityEngine;

public class MonsterDeathState : MonsterBaseState
{
    Animator animator;
    
    public MonsterDeathState(MonsterState monsterST) : base(monsterST) { }

    public override void OnMonsterStateEnter()
    {
        animator = _monsterState.GetComponent<Animator>();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            animator.SetTrigger("Death");
    }
    public override void OnMonsterStateUpdate()
    {

    }

    public override void OnMonsterStateExit()
    {

    }
}
