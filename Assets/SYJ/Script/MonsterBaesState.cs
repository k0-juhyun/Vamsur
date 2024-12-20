public abstract class MonsterBaseState  //�߻�ȭ �۾�. �̰��� ������ ���Ϳ��� ���� ���̱� ����. ���� �� �߻�ȭ �� ���� �ٸ� �׼ǿ� ����� ���̴�.
{
    protected MonsterState _monsterState;

    protected MonsterBaseState(MonsterState monsterST)
    {
        _monsterState = monsterST;
    }

    public abstract void OnMonsterStateEnter();     //ó�� ������ �� �� ���� ���� �� ��.
    public abstract void OnMonsterStateUpdate();     //�� ������ ����
    public abstract void OnMonsterStateExit();     //���� ���� �� �� ���� ���� �� ��.
}