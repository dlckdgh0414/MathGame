using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipLaser : MonoBehaviour
{
	private Lazer _lazerAttack;
    [SerializeField]private Transform[] _lazerPos;
    [SerializeField] private Quaternion[] _shotRot;

    private void Awake()
    {
        _lazerAttack = GetComponent<Lazer>();
    }

    private void OnEnable()
    {
        StartCoroutine(LaserShot());
    }

    private IEnumerator LaserShot()
    {
        //_lazerAttack.ShotExpolmeArr(_lazerPos, _shotRot);
        //yield return new WaitForSeconds(1f);
        while (true)
        {
            _lazerAttack.ShootLazerArr(_lazerPos, _shotRot);
            yield return new WaitForSeconds(0.3F);
            Ipoolable item = GetComponent<Ipoolable>();
            PoolManager.Instance.Push(item);
        }
    }
}
