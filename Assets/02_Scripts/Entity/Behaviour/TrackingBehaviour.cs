using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBehaviour : MonoBehaviour, ITrackingBehaviour
{
    [SerializeField]
    private LayerMask targetLayer;
    [SerializeField]
    private StateType nextState;

    private float trackingRange;
    private float attackRange;
    private BaseEntity owner;

    private Transform target;

    public void InitTracking(BaseEntity owner)
    {
        trackingRange = owner.BehaviourData.TrackingRange;
        attackRange = owner.BehaviourData.AttackRange;
        this.owner = owner;
    }

    public void OnTracking()
    {
        if (target == null)
            SearchTarget();

        else
            Tracking();
    }
    private void SearchTarget()
    {
        // Ÿ�� Ž�� ���� �� TargetLayer Ȯ��
        Collider[] targets = Physics.OverlapSphere(transform.position, trackingRange, targetLayer);

        // ���� �������
        float distance = int.MaxValue;
        foreach (Collider collider in targets)
        {
            float newdistance = Vector3.Distance(transform.position, collider.transform.position);
            if (newdistance < distance)
            {
                distance = newdistance;
                target = collider.transform;
            }
        }
    }
    private void Tracking()
    {
        
    }
}
