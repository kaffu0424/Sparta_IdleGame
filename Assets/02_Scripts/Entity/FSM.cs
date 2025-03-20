using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private BaseEntity owner;

    [SerializeField] private StateType currentStateType;
    private Dictionary<StateType, BaseState> states;
    private BaseState currentState;

    public FSM(BaseEntity owner)
    {
        this.owner = owner;
        states = new Dictionary<StateType, BaseState>();

        currentStateType = StateType.Idle;
        BaseState idle = CreateState(currentStateType);
        currentState = idle;
        currentState?.Enter();
        states.Add(currentStateType, idle);
    }

    public void Execute()
    {
        currentState?.Execute();
    }

    public void ChangeState(StateType type)
    {
        // ���� ���� ����
        currentState?.Exit();

        // ���� ���� ��������
        if (!states.TryGetValue(type, out currentState))
        {
            // ���� ���°� ������ ���� ���� �� ����
            BaseState newState = CreateState(type);
            currentState = newState;

            states.Add(type, newState);
        }

        currentState?.Enter();
    }

    private BaseState CreateState(StateType type)
    {
        switch(type)
        {
            case StateType.Idle:
                return new IdleState(owner);
            case StateType.Tracking:
                return new TrackingState(owner);
            case StateType.Attack:
                return new AttackState(owner);
        }

        return null;
    }
}
