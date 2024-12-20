using System.Collections;
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
    private IEnumerator CheckMonsterState()
    {
        switch (_monsterST)
        {
            case MonsterST.Idle:
                yield return new WaitForSeconds(1.0f);
                break;
            case MonsterST.Patrol:
                yield return new WaitForSeconds(1.0f);
                break;
            case MonsterST.Attack:
                yield return new WaitForSeconds(1.0f);
                break;
            case MonsterST.Hit:
                yield return new WaitForSeconds(1.0f);
                break;
            case MonsterST.Death:
                yield return new WaitForSeconds(1.0f);
                break;
        }
        yield return new WaitForSeconds(0.3f);
    }
}