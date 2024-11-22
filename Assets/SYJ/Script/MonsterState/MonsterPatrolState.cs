using UnityEngine;

public class MonsterPatrolState : MonsterBaseState
{
    Animator animator;

    public MonsterPatrolState(MonsterState monsterST) : base(monsterST) { }

    public override void OnMonsterStateEnter()
    {
        Debug.Log("Patrol");

        animator = _monsterState.GetComponent<Animator>();

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Patrol"))
            animator.SetTrigger("Patrol");
    }
    public override void OnMonsterStateUpdate()
    {

    }
    public override void OnMonsterStateExit()
    {

    }
}
