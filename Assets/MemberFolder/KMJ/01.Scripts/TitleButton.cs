using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    public GameObject _mainScreen; 
    public GameObject _gameScene;
    public GameObject _titleScene;
    public GameObject _player;
    public GameObject _manager;

    private void Start()
    {
        _player.SetActive(false);
        _manager.SetActive(false);
    }

    public void SelectEnter()
    {
        _mainScreen.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
