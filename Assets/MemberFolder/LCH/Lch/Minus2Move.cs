using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus2Move : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector3 _moveDir;

    public Pooling _lazer;
    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("LastPos");
        _moveDir = target.transform.position - transform.position;
        _moveDir.Normalize();
    }
    private void Update()
    {
        transform.position += _moveDir * (_moveSpeed * Time.deltaTime);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Minus2"))
        {
            Ipoolable item = GetComponent<Ipoolable>();
            PoolManager.Instance.Push(item);
           _lazer = PoolManager.Instance.Pop("MultiplicationAttack2") as Pooling;
            if(_lazer != null)
            {
                _lazer.transform.position = target.transform.position;
            }
        }
    }
}
