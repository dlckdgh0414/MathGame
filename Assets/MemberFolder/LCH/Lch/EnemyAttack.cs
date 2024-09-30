using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private Health _playerHealth;
    private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("АјАн");
            _playerHealth = GameObject.Find("Player").GetComponent<Health>();
            _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
            _playerHealth.MinusDamage(_enemy._enemystats.AttackPower);
        }
    }
}
