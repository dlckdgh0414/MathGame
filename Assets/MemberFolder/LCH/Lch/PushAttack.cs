using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{
    private Lazer _lazer;

    [SerializeField] private Transform[] _pos;
    [SerializeField] private Quaternion[] _rot;

    private void Awake()
    {
        _lazer = GetComponentInParent<Lazer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PrefabPushZone"))
        {

            _lazer.ShotExpolmeArr(_pos,_rot,null);
            _lazer.ShootLazerArr(_pos,_rot,null);

            Ipoolable item = gameObject.GetComponentInParent<Ipoolable>();
            if (item != null)
            {
                PoolManager.Instance.Push(item);
                GameManager.Instance._EnemyTrunEnd = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
