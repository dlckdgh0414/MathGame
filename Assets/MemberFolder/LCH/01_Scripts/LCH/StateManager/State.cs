using System;
using UnityEngine;

public class State<T> where T : Enum
{
    protected EnemyAgent _agent;
    protected int _animBoolHash;
    protected StateMachine<T> _stateMachine;
    protected bool _endTriggerCalled;

    public State(EnemyAgent _onwer, StateMachine<T> state, string animHashName)
    {
        _agent = _onwer;
        _stateMachine = state;
        _animBoolHash = Animator.StringToHash(animHashName);
    }


    public virtual void UpdateState()
    {
        
    }

    public virtual void Enter()
    {
        _agent.AnimatorComponent.SetBool(_animBoolHash, true);
        _endTriggerCalled = false;

    }
    public virtual void Exit()
    {
        _agent.AnimatorComponent.SetBool(_animBoolHash, false);
    }

    public virtual void LateUpdateState()
    {

    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
