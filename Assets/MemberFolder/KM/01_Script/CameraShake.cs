using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public void CameraShaking()
    {
        transform.DOShakePosition(0.5f, 2f, 45);
    }
}
