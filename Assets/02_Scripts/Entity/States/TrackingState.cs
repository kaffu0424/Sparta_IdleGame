public class TrackingState : BaseState
{
    ITrackingBehaviour trackingBehaviour;
    public TrackingState(BaseEntity owner) : base(owner)
    {
        // owner ������Ʈ�� Tracking �������̽� ��������
        owner.TryGetComponent(out trackingBehaviour);
    }

    public override void Enter()
    {
        animator.SetBool("Tracking", true);
    }

    public override void Execute()
    {
        trackingBehaviour?.OnTracking();
    }

    public override void Exit()
    {
        animator.SetBool("Tracking", false);
    }
}