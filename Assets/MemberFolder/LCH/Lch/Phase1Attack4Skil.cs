using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Phase1Attack4Skil : MonoBehaviour
{
	public void Phase1Attack4()
    {
        StartCoroutine(Attack4());
    }

    private IEnumerator Attack4()
    {
        while (true)
        {
            transform.position = new Vector2(Random.Range(3.37f, -3.26f),transform.position.y);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
