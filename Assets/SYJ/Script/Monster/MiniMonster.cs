using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMonster : MonsterState
{
    private enum MonsterST
    {
        Idle,
        Patrol,
        Attack,
        Hit,
        Death
    }
    private MonsterST _monsterST;
    private MonsterFSM _monsterFSM;

    // Start is called before the first frame update
    void Start()
    {
        _monsterST = MonsterST.Idle;
        _monsterFSM = new MonsterFSM(new MonsterIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        switch (_monsterST)
        {
            case MonsterST.Idle:
                break;
            case MonsterST.Patrol:
                break;
            case MonsterST.Attack:
                break;
            case MonsterST.Hit:
                break;
            case MonsterST.Death:
                break;
        }

        _monsterFSM.UpdateState();
    }

    private void ChangeState(MonsterST nextState)
    {
        _monsterST = nextState;

        switch (_monsterST)
        {
            case MonsterST.Idle:
                _monsterFSM.ChangeState(new MonsterIdleState(this));
                break;
            case MonsterST.Patrol:
                _monsterFSM.ChangeState(new MonsterPatrolState(this));
                break;
            case MonsterST.Attack:
                _monsterFSM.ChangeState(new MonsterAttackState(this));
                break;
            case MonsterST.Hit:
                _monsterFSM.ChangeState(new MonsterHitState(this));
                break;
            case MonsterST.Death:
                _monsterFSM.ChangeState(new MonsterDeathState(this));
                break;
        }
    }
}
