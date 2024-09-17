using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private Health _playerHealth;
    private EnemyStatsSo _enemy;

    private void Awake()
    {
        _playerHealth = GameObject.Find("Player").GetComponent<Health>();
        _enemy = GetComponentInParent<EnemyStatsSo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerHealth.MinusDamage(_enemy.AttackPower);
    }
}
