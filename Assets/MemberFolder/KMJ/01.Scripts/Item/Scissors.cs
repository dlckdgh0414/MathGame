using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public void scissors()
    {
        GameManager.Instance.state = GameManager.TrunState.playerTurn;
    }
}
