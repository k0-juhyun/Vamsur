using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MiniMonster : MonsterState
{
    public float MonsterHP { get; set; }
    public Vector3 monsterDistance;
    public GameObject player;
    public NavMeshAgent nmAgent;
    public float monsterDamager;

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
        _monsterSt = MonsterST.Patrol;
        _monsterFSM = new MonsterFSM(new MonsterIdleState(this));
        nmAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        nmAgent.SetDestination(player.transform.position);
        StartCoroutine(MonsterClash());

        if (Input.GetKey(KeyCode.E))
        {
            MonsterHitDamage(1);
        }
    }

    public void MonsterHitDamage(float damage)
    {
        ChangeState(MonsterST.Hit);

        MonsterHP -= damage;

        if (MonsterHP < 0)
        {
            ChangeState(MonsterST.Death);
        }
    }

    public float MonsterTakeDamage()
    {
        return monsterDamager;
    }

    private IEnumerator MonsterClash()
    {
        switch (_monsterSt)
        {
            case MonsterST.Idle:
                yield return null;
                break;
            case MonsterST.Patrol:
                if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
                {
                    ChangeState(MonsterST.Attack);
                }
                yield return null;
                break;
            case MonsterST.Attack:
                if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
                {
                    ChangeState(MonsterST.Patrol);
                }
                yield return null;
                break;
            case MonsterST.Hit:
                if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
                {
                    ChangeState(MonsterST.Patrol);
                }
                if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
                {
                    ChangeState(MonsterST.Attack);
                }
                yield return null;
                break;
            case MonsterST.Death:
                Destroy(gameObject);
                yield return null;
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
