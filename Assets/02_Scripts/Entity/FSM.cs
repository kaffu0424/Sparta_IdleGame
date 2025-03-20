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
        // 현재 상태 퇴장
        currentState?.Exit();

        // 다음 상태 가져오기
        if (!states.TryGetValue(type, out currentState))
        {
            // 다음 상태가 없으면 상태 생성 후 저장
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
