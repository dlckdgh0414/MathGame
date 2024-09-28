using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus3Move : MonoBehaviour
{

    [SerializeField] private float _speed;

    private Vector2 _moveDir;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _moveDir = Vector2.down;
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.down * _speed;
    }

}
