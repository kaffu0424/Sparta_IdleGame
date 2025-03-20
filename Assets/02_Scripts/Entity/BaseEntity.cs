using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    protected FSM fsm;

    private void Start()
    {
        fsm = new FSM(this);
    }

    private void Update()
    {
        fsm.Execute();
    }
}
