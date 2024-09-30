using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTxt : MonoBehaviour
{
    [SerializeField] private GameObject _gameScene;
    [SerializeField] private GameObject _titleScene;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _manager;

    private void Awake()
    {
    }

    public void ClickStartButton()
    {
        _manager.SetActive(true);
        GameManager.Instance.cut = 0;
        _player.SetActive(true);
        _gameScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ClickSecondButton()
    {
        _manager.SetActive(true);
        GameManager.Instance.cut = 1;
        _player.SetActive(true);
        _gameScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ClickThirdButton()
    {
        _manager.SetActive(true);
        GameManager.Instance.cut = 2;
        _player.SetActive(true);
        _gameScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ClickFourthButton()
    {
        _manager.SetActive(true);
        GameManager.Instance.cut = 3;
        _player.SetActive(true);
        _gameScene.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ClickFifthButton()
    {
        _manager.SetActive(true);
        GameManager.Instance.cut = 4;
        _player.SetActive(true);
        _gameScene.SetActive(true);
        gameObject.SetActive(false);
    }


    public void ClickBack()
    {
        gameObject.SetActive(false);
        _titleScene.SetActive(true);
    }
}
