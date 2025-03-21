using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : MonoBehaviour, IIdleBehaviour
{
    [SerializeField]
    private LayerMask targetLayer;
    [SerializeField]
    private StateType nextState;

    private float trackingRange;
    private BaseEntity owner;

    public void InitIdle(BaseEntity owner)
    {
        trackingRange = owner.BehaviourData.TrackingRange;
        this.owner = owner;
    }

    public void OnIdle()
    {
        // 타겟 탐지 범위 내 TargetLayer 확인
        Collider[] targets = Physics.OverlapSphere(transform.position, trackingRange, targetLayer);

        // 있으면 nextState로 상태변경
        if(targets.Length > 0 )
            owner.Fsm.ChangeState(nextState);
    }
}
