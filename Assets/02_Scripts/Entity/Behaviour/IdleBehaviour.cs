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
        // Ÿ�� Ž�� ���� �� TargetLayer Ȯ��
        Collider[] targets = Physics.OverlapSphere(transform.position, trackingRange, targetLayer);

        // ������ nextState�� ���º���
        if(targets.Length > 0 )
            owner.Fsm.ChangeState(nextState);
    }
}
