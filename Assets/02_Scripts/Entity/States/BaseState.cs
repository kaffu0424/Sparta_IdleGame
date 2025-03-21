using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected BaseEntity owner;
    protected Animator animator;
    public BaseState(BaseEntity owner)
    {
        this.owner = owner;
        animator = owner.GetComponentInChildren<Animator>();
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}