using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public GameObject gameScreen;
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
        gameScreen.SetActive(false);
        mainScreen.SetActive(true);
        gameObject.SetActive(false);
        GameObject.Find("Player").SetActive(false);
        GameObject.FindWithTag("Enemy").SetActive(false);
    }
}
