using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Behaviour Data", menuName = "Object Data/Behaviour Data", order = int.MaxValue)]
public class BehaviourData : ScriptableObject
{
    public float TrackingRange;
    public float AttackRange;
}
