using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;

    public void Transition()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        float time = 0.5f;
        float currentTime = 0f;
        float percent = 0;

        while (percent > 0)
        {
            currentTime += Time.deltaTime;
            percent = time - (currentTime / time);

            float t = Mathf.Lerp(0, 2, percent);
            _transitionImage.material.SetFloat("_Strength", percent);

            yield return null;
            Debug.Log(percent);
        }
        Debug.Log("bbb");
    }
}
