using System.Collections;
using UnityEngine;

public enum EnemyStateEnum
{
   plus,Hit,Dead
}
public class Enemy : EnemySetting
{
    public StateMachine<EnemyStateEnum> StateMachine { get; set; }

    public void GetHit()
    {
        StateMachine.ChangeState(EnemyStateEnum.Hit);
    }

    public override void SetDeadState()
    {
        StateMachine.ChangeState(EnemyStateEnum.Dead);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
}
