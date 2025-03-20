public class IdleState : BaseState
{
    private IIdleBehaviour idleBehaviour;

    public IdleState(BaseEntity owner) : base(owner)
    {
        // owner 오브젝트의 Idle 인터페이스 가져오기
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