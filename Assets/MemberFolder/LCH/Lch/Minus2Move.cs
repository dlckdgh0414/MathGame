using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus2Move : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector3 _moveDir;

    private void Start()
    {
        if(transform.position.x< 0)
        {
            transform.rotation = Quaternion.Euler(0,0,-45);
        }
        GameObject target = GameObject.Find("LastPos");
        _moveDir = target.transform.position - transform.position;
        _moveDir.Normalize();
    }
    private void Update()
    {
        transform.position += _moveDir * (_moveSpeed * Time.deltaTime);
    }
}
