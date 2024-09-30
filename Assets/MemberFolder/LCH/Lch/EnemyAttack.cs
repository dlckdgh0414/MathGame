using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAttack : MonoBehaviour
{
	private Health _playerHealth;
    private Enemy _enemy;
    private AudioSource _hitSound;

    private void Awake()
    {
        _hitSound = GameObject.Find("PigutSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hitSound.Play();
            Debug.Log("АјАн");
            _playerHealth = GameObject.Find("Player").GetComponent<Health>();
            _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
            _playerHealth.MinusDamage(_enemy._enemystats.AttackPower);
        }
    }
}
