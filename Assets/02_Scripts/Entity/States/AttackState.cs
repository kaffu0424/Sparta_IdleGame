public class AttackState : BaseState
{
    private IAttackBehaviour attackBehaviour;
    public AttackState(BaseEntity owner) : base(owner) 
    {
        // owner ������Ʈ�� Attack �������̽� ��������
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