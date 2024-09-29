using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    public GameObject _mainScreen; 
    private GameObject _gameScene;
    private GameObject _titleScene;
    private GameObject _player;
    private GameObject _manager;

    private void Awake()
    {
        _manager = GameObject.Find("Manager");
        _player = GameObject.Find("Player");
        _titleScene = GameObject.Find("*****TitleScreen*****");
        _gameScene = GameObject.Find("*****FightScreen*****");
    }

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
