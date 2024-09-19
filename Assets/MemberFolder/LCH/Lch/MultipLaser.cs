using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipLaser : MonoBehaviour
{
	private Lazer _lazerAttack;
    [SerializeField]private Transform[] _lazerPos;
    [SerializeField] private Quaternion[] _shotRot;

    Pooling _enmy;

    private void Awake()
    {
        _lazerAttack = GetComponent<Lazer>();
    }

    private void Start()
    {
        StartCoroutine(LaserShot());
    }

    private IEnumerator LaserShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _lazerAttack.ShootLazer(_lazerPos,_shotRot);
            yield return new WaitForSeconds(1.2f);
            Ipoolable item = GetComponent<Pooling>().GetComponent<Ipoolable>();
            PoolManager.Instance.Push(item);

        }
    }
}
