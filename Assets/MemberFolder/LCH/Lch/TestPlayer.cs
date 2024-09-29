using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
	private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        Debug.Log($"{_health.Hp}");
    }
}
