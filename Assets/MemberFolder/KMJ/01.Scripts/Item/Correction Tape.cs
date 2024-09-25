using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectionTape : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GameObject.Find("Player").GetComponent<Health>();
    }
    public void CorrectrionTapeBe()
    {
        _health.Hp = 100;
        GameManager.Instance.state = GameManager.TrunState.playerTurn;
        Debug.Log(_health.Hp);
    }
}
