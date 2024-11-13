public class MonsterFSM     //MonsterBaseState�� ���� ����, ���� ���� �� ȣ�� �� Ŭ����.
{
    public MonsterFSM(MonsterBaseState initState) 
    {
        _curState = initState;
        ChangeState(_curState);
    }
    private MonsterBaseState _curState;

    public void ChangeState(MonsterBaseState nextState)
    {
        if (_curState == nextState)
            return;

        if (_curState != null)
            _curState.OnMonsterStateEnter();

        _curState = nextState;
        _curState.OnMonsterStateEnter();
    }

    public void UpdateState()
    {
        if ( _curState != null)
            _curState.OnMonsterStateUpdate();
    }
}
