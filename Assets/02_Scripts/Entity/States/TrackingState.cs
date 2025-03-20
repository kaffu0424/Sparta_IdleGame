public class TrackingState : BaseState
{
    ITrackingBehaviour trackingBehaviour;
    public TrackingState(BaseEntity owner) : base(owner)
    {
        // owner 오브젝트의 Tracking 인터페이스 가져오기
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