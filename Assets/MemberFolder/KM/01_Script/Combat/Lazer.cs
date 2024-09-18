using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Lazer : MonoBehaviour
{
    public Pooling lazer;
    private SpriteRenderer _lazerSprite;
    private Sequence seq;

    public GameObject player;

    public void Shoot()
    {
        int rand = Random.Range(0, 360);
        ShootLazer(player.transform.position, Quaternion.Euler(0, 0, rand));
    }

    public void ShootLazer(Vector3 pos, Quaternion rot)
    {
        lazer = PoolManager.Instance.Pop("Lazer") as Pooling;
        _lazerSprite = lazer.GetComponent<SpriteRenderer>();
        seq = DOTween.Sequence();

        if (lazer != null)
        {
            lazer.gameObject.transform.position = pos;
            lazer.transform.rotation = rot;
            lazer.transform.localScale = new Vector3(0, lazer.transform.localScale.y);
        }

        seq.Append(lazer.transform.DOScaleX(1, 0.5f)
            .SetEase(Ease.OutElastic))
            .Append(lazer.transform.DOScaleX(0, 0.25f));
    }
}
