using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlusAttack : MonoBehaviour
{
    private void Update()
    {
        transform.DORotate(new Vector3(0, 0, 360), 0.4f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental);


    }
}
