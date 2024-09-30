using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
	[SerializeField] private Image _enemyHp;

	private Enemy _enemy;

    private void Start()
    {
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }


    private void Update()
    {
        _enemyHp.fillAmount = _enemy.HelathCompo.Hp;
    }

}
