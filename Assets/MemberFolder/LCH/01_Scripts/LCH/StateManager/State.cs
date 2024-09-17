using System;
using UnityEngine;

public class State<T> where T : Enum
{
    protected EnemyAgent _agent;
    protected StateMachine<T> _stateMachine;
    protected bool _endTriggerCalled;

    public State(EnemyAgent _onwer, StateMachine<T> state)
    {
        _agent = _onwer;
        _stateMachine = state;
    }


    public virtual void UpdateState()
    {
        
    }

    public virtual void Enter()
    {
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
    }

    public virtual void LateUpdateState()
    {

    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
