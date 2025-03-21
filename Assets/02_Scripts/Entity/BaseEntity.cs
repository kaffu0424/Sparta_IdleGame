using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    [SerializeField]
    protected BehaviourData behaviourData;

    protected FSM fsm;
    public BehaviourData BehaviourData { get { return behaviourData; } }
    public FSM Fsm { get { return fsm; } }  

    private void Start()
    {
        fsm = new FSM(this);
    }

    private void Update()
    {
        fsm.Execute();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, behaviourData.TrackingRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, behaviourData.AttackRange);
    }
}
