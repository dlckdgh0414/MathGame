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

    private void Start()
    {
        //StartCoroutine(LaserShot());
    }

    private void OnEnable()
    {
        StartCoroutine(LaserShot());
    }

    private void OnDisable()
    {
    }

    private IEnumerator LaserShot()
    {
        yield return new WaitUntil(() => PoolManager.Instance.IsInitEnd);
        Debug.Log("Laser");
        _lazerAttack.ShotExpolmeArr(_lazerPos, _shotRot, null);
        yield return new WaitForSeconds(1f);
        _lazerAttack.ShootLazerArr(_lazerPos, _shotRot, null);
        yield return new WaitForSeconds(0.5f);
         Ipoolable item = GetComponent<Ipoolable>();
         PoolManager.Instance.Push(item);
        GameManager.Instance._EnemyTrunEnd = true;
            
    }
}
