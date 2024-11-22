using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMonster : MonsterState
{
    public int MonsterHP { get; set; }

    private enum MonsterST
    {
        Idle,
        Patrol,
        Attack,
        Hit,
        Death
    }
    private MonsterST _monsterSt;
    private MonsterFSM _monsterFSM;

    // Start is called before the first frame update
    void Start()
    {
        _monsterSt = MonsterST.Idle;
        _monsterFSM = new MonsterFSM(new MonsterIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        switch (_monsterSt)
        {
            case MonsterST.Idle:
                if (Input.GetKeyDown(KeyCode.W))        //юс╫ц
                {
                    ChangeState(MonsterST.Patrol);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    ChangeState(MonsterST.Attack);
                }
                break;
            case MonsterST.Patrol:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    ChangeState(MonsterST.Attack);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ChangeState(MonsterST.Idle);
                }
                break;
            case MonsterST.Attack:
                if (Input.GetKeyDown(KeyCode.W))
                {
                    ChangeState(MonsterST.Patrol);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ChangeState(MonsterST.Idle);
                }
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
        _monsterSt = nextState;

        switch (_monsterSt)
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
