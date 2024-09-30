using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
	private Health _health;
    [SerializeField] private GameObject _endUI;
    private void Awake()
    {
        _endUI.SetActive(false); 
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        Debug.Log($"{_health.Hp}");
        PlayerDie();
    }

    public void PlayerDie()
    {
        if(_health.Hp <= 0)
        {
            _endUI.SetActive(true);
        }
    }
}
