using UnityEngine;

public class MonsterState : MonoBehaviour
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

    void Start()
    {
        _monsterST = MonsterST.Idle;
    }

    // Update is called once per frame
    private void Update()
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
    }
}