using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{

    public GameObject mainScreen;
    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void ClickContinue()
    {
        GameObject.Find("Player").TryGetComponent(out Health health);
        health.Hp = 100;
        GameManager.Instance.BattleStart();
        gameObject.SetActive(false);
    }

    public void ClickExit()
    {
        mainScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
