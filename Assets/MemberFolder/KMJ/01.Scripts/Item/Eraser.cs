using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    private Health _player;


    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Health>();
    }


    public void EraserPowder()
    {
        _player.PlusDamage(7);

        GameManager.Instance.OnEnemyAttackStart.Invoke();
        if (_player.Hp >= 100)
        {
            _player.Hp = 100;
        }
    }
    public void EraserSculpture()
    {
        GameManager.Instance.OnEnemyAttackStart.Invoke();
        _player.PlusDamage(25);
        if (_player.Hp >= 100)
        {
            _player.Hp = 100;
        }
    }
    public void PerforatedEraser()
    {
        GameManager.Instance.OnEnemyAttackStart.Invoke();
        _player.PlusDamage(50);
        if(_player.Hp >= 100)
        {
            _player.Hp = 100;
        }
    }

    public void PerfectEraser()
    {
        GameManager.Instance.OnEnemyAttackStart.Invoke();
        _player.Hp = 100;
    }

}
