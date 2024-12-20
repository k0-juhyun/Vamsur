public abstract class MonsterBaseState  //추상화 작업. 이것은 오로지 몬스터에만 쓰일 것이기 때문. 따라 이 추상화 된 것을 다른 액션에 상속할 것이다.
{
    protected MonsterState _monsterState;

    protected MonsterBaseState(MonsterState monsterST)
    {
        _monsterState = monsterST;
    }

    public abstract void OnMonsterStateEnter();     //처음 진입할 때 한 번만 실행 될 것.
    public abstract void OnMonsterStateUpdate();     //매 프레임 실행
    public abstract void OnMonsterStateExit();     //상태 변경 시 한 번만 실행 될 것.
}