public interface IIdleBehaviour
{
    public void OnIdle();
    public void InitIdle(BaseEntity owner);
}
public interface ITrackingBehaviour
{
    public void OnTracking();
    public void InitTracking(BaseEntity owner);
}
public interface IAttackBehaviour
{
    public void OnAttack();
    public void InitAttack(BaseEntity owner);
}