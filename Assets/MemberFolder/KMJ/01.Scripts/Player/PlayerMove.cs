using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected InputReader _playerinput;

    public float xMove;

    public float yMove;

    public Vector2 moveDir { get; set; }

    protected Rigidbody2D _rigid;
    [field: SerializeField] public float moveSpeed { get; set; }

    public bool IsCanMove { get; set; } = true;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void SetMove(float Xmove, float Ymove)
    {
        xMove = Xmove;
        yMove = Ymove;

        moveDir = new Vector2(xMove, yMove);
    }

    private void Update()
    {
        SetMove(_playerinput.Move.x, _playerinput.Move.y);
    }

    private void FixedUpdate()
    {
        if (IsCanMove)
            _rigid.velocity = new Vector2(xMove * moveSpeed, yMove * moveSpeed);
    }

}
