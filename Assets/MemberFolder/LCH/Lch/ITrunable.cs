using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TrunState
{
    Enemy,
    Player
}
public interface ITrunable<T> where T : Enum
{
	public void CurrentTrun(T CrueentTrune , bool EndTrune = false)
    {
        if (EndTrune)
        {
            NextTrune();
        }
    }

    public void NextTrune()
    {

    }
}
