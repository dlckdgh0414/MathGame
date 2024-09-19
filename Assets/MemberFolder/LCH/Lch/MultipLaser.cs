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
        StartCoroutine(LaserShot());
    }

    private IEnumerator LaserShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _lazerAttack.ShootLazer(_lazerPos,_shotRot);
        }
    }
}
