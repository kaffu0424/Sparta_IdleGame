public class IdleState : BaseState
{
    private IIdleBehaviour idleBehaviour;

    public IdleState(BaseEntity owner) : base(owner)
    {
        // owner ������Ʈ�� Idle �������̽� ��������
        owner.TryGetComponent(out idleBehaviour);
    }

    public override void Enter()
    {
        animator.SetBool("Idle", true);
    }

    public override void Execute()
    {
        idleBehaviour?.OnIdle();
    }

    public override void Exit()
    {
        animator.SetBool("Idle", false);
    }
}