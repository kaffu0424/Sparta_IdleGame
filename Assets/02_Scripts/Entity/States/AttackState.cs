public class AttackState : BaseState
{
    private IAttackBehaviour attackBehaviour;
    public AttackState(BaseEntity owner) : base(owner) 
    {
        // owner 오브젝트의 Attack 인터페이스 가져오기
        owner.TryGetComponent(out attackBehaviour);
    }

    public override void Enter()
    {
        animator.SetBool("Attack", true);
    }

    public override void Execute()
    {
        attackBehaviour?.OnAttack();
    }

    public override void Exit()
    {
        animator.SetBool("Attack", false);
    }
}