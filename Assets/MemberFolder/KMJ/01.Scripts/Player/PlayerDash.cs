using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [field:SerializeField] public float _dashSpeed { get; set; }
    [SerializeField] private InputReader _playerinput;
    [SerializeField] private PlayerMove _playerMove;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _playerinput.DashKeyEvent += DashEventHander;
    }
    private void DashEventHander()
    {
        StartCoroutine(DashWait());
    }


    private IEnumerator DashWait()
    {
        _rigid.AddForce(_playerMove.moveDir * _dashSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(5f);
    }
}
