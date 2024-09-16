using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [field:SerializeField] public float _dashSpeed { get; set; }
    [SerializeField] private InputReader _playerinput;
    [SerializeField] private PlayerMove _playerMove;

    public bool isDash;

    private void Start()
    {
        _playerinput.DashKeyEvent += DashEventHander;
    }
    private void DashEventHander()
    {
        StartCoroutine(DashWait());
    }


    private IEnumerator DashWait()
    {
        _playerMove.moveSpeed = _dashSpeed;

        yield return new WaitForSeconds(0.1f);

        _playerMove.moveSpeed = 10;

        yield return new WaitForSeconds(5f - 0.2f);
    }
}
