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

    public void ClickButton()
    {
        _manager.SetActive(true);
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
