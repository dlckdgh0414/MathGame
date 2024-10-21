using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	[SerializeField] private ProbelmsReader _reader;
	[SerializeField] private TextMeshProUGUI _loadingText;
	[SerializeField] private string _gameScene;

    private void Awake()
    {
        _reader.OnDataLoaded += HandleDataLoaded;
    }

    private void OnDestroy()
    {
        _reader.OnDataLoaded -= HandleDataLoaded;
    }

    private void HandleDataLoaded()
    {
        _loadingText.text = "로딩 완료!";
        DOVirtual.DelayedCall(1f, () => SceneManager.LoadScene(_gameScene));
    }
}
