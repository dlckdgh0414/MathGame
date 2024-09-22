using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlusMove2 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector3 _moveDir;
    private void Update()
    {
        GameObject target = GameObject.Find("Player");
        _moveDir = target.transform.position - transform.position;
        _moveDir.Normalize();
        transform.position += _moveDir * (_moveSpeed * Time.deltaTime);
        transform.DORotate(new Vector3(0, 0, 360), 0.4f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental);
    }
}
