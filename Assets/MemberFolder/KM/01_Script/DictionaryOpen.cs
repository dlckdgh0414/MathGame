using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class DictionaryOpen : MonoBehaviour
{
    [SerializeField] private GameObject _dic;
    [SerializeField] private GameObject _player;
    private GameObject _enemy;

    private bool isOpne = false;

    public void OnDictionaryClick()
    {
        _enemy = GameObject.FindWithTag("Enemy");
        isOpne = !isOpne;

        _player.gameObject.GetComponent<SpriteRenderer>().enabled = !isOpne;
        _enemy.gameObject.GetComponent<SpriteRenderer>().enabled = !isOpne;
        _dic.SetActive(isOpne);
    }
}
