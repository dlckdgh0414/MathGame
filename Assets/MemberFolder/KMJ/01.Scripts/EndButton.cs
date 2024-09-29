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
        SceneManager.LoadScene("GameScene");   
    }

    public void ClickExit()
    {
       // mainScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
