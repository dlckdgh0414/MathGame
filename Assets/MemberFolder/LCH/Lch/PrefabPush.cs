using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPush : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PrefabPushZone"))
        {
            Ipoolable item = gameObject.GetComponentInParent<Ipoolable>();
            if (item != null)
            {
                PoolManager.Instance.Push(item);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
