using UnityEngine;

public class ItemButtonTrue : MonoBehaviour
{
    [SerializeField] private GameObject _itemBag;
    public bool _isOpen;

    private void Awake()
    {
        _isOpen = false;
        _itemBag.SetActive(false);
    }


    public void OpenItemBag()
    {
        if (_isOpen == false)
        { 
            _itemBag.SetActive(true);
            _isOpen = true;
        }
        else if(_isOpen == true)
        {
            _itemBag.SetActive(false);
            _isOpen = false;
        }
    }
}
